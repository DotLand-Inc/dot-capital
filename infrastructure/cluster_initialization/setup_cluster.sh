#!/bin/bash

# Kubernetes Cluster Setup Script
# Orchestrates deployment across servers listed in 'servers' file

set -e

SERVERS_FILE="servers"
BOOTSTRAP_SCRIPT="k8s_bootstrap.sh"
DOMAIN="dotland.fr"

# Check prerequisites
if ! command -v sshpass &> /dev/null; then
    echo "Error: sshpass is not installed."
    exit 1
fi

if [ ! -f "$SERVERS_FILE" ]; then
    echo "Error: servers file not found."
    exit 1
fi

echo "=================================================="
echo "Starting Kubernetes Cluster Deployment"
echo "=================================================="

# Arrays to hold server info
declare -a IPS
declare -a PASSWORDS
declare -a ROLES

# Read servers file
while read -r ip password role; do
    if [[ "$ip" =~ ^[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+$ ]]; then
        IPS+=("$ip")
        PASSWORDS+=("$password")
        ROLES+=("$role")
    fi
done < "$SERVERS_FILE"

# 1. Bootstrap All Nodes
echo ">>> Phase 1: Bootstrapping all nodes..."
for i in "${!IPS[@]}"; do
    IP="${IPS[$i]}"
    PASS="${PASSWORDS[$i]}"
    ROLE="${ROLES[$i]}"
    
    echo "Configuring Node: $IP ($ROLE)"
    
    # Check if already bootstrapped
    if sshpass -p "$PASS" ssh -o StrictHostKeyChecking=no "root@$IP" "command -v kubeadm &> /dev/null"; then
        echo "Node $IP is already bootstrapped (kubeadm found). Skipping bootstrap."
    else
        # Add host key to known_hosts to avoid prompt
        mkdir -p ~/.ssh
        ssh-keyscan -H "$IP" >> ~/.ssh/known_hosts 2>/dev/null || true

        # Copy bootstrap script
        sshpass -p "$PASS" scp -o StrictHostKeyChecking=no "$BOOTSTRAP_SCRIPT" "root@$IP:/root/$BOOTSTRAP_SCRIPT"
        
        # Execute bootstrap script
        sshpass -p "$PASS" ssh -o StrictHostKeyChecking=no "root@$IP" "chmod +x /root/$BOOTSTRAP_SCRIPT && /root/$BOOTSTRAP_SCRIPT"
        
        echo "Node $IP bootstrapped successfully."
    fi
done


# 2. Configure Master
echo ">>> Phase 2: Configuring Master Node..."

JOIN_COMMAND=""

for i in "${!IPS[@]}"; do
    if [[ "${ROLES[$i]}" == "MASTER" ]]; then
        MASTER_IP="${IPS[$i]}"
        MASTER_PASS="${PASSWORDS[$i]}"
        
        # Check if already initialized
        if sshpass -p "$MASTER_PASS" ssh -o StrictHostKeyChecking=no "root@$MASTER_IP" "test -f /etc/kubernetes/admin.conf"; then
             echo "Master already initialized. Skipping init."
        else
             echo "Initializing Master at $MASTER_IP..."
             
             # Add hosts entry
             sshpass -p "$MASTER_PASS" ssh -o StrictHostKeyChecking=no "root@$MASTER_IP" "grep -q '$DOMAIN' /etc/hosts || echo '$MASTER_IP $DOMAIN' >> /etc/hosts"
             
             # Init
             INIT_OUTPUT=$(sshpass -p "$MASTER_PASS" ssh -o StrictHostKeyChecking=no "root@$MASTER_IP" "kubeadm init --control-plane-endpoint=$DOMAIN --upload-certs --pod-network-cidr=192.168.0.0/16")
             echo "$INIT_OUTPUT"
             
             # Setup kubectl
             sshpass -p "$MASTER_PASS" ssh -o StrictHostKeyChecking=no "root@$MASTER_IP" "mkdir -p /root/.kube && cp -i /etc/kubernetes/admin.conf /root/.kube/config && chown root:root /root/.kube/config"
             
             # Install Calico
             echo "Installing Calico CNI..."
             sshpass -p "$MASTER_PASS" ssh -o StrictHostKeyChecking=no "root@$MASTER_IP" "kubectl apply -f https://raw.githubusercontent.com/projectcalico/calico/v3.26.1/manifests/calico.yaml"
        fi
        
        # Get Join Command (Reliabily)
        echo "Retrieving fresh join command..."
        JOIN_COMMAND=$(sshpass -p "$MASTER_PASS" ssh -o StrictHostKeyChecking=no "root@$MASTER_IP" "kubeadm token create --print-join-command")
        
        if [ -z "$JOIN_COMMAND" ]; then
            echo "Error: Failed to retrieve join command."
            exit 1
        fi
        
        break
    fi
done

if [ -z "$JOIN_COMMAND" ]; then
    echo "Error: No MASTER node processed."
    exit 1
fi

# 3. Join Worker Nodes
echo ">>> Phase 3: Joining Worker Nodes..."
# Clean command just in case, though token create output is usually clean
CLEAN_JOIN_COMMAND=$(echo $JOIN_COMMAND | tr -d '\r' | tr -d '\n')

for i in "${!IPS[@]}"; do
    if [[ "${ROLES[$i]}" == "NODE" ]]; then
        NODE_IP="${IPS[$i]}"
        NODE_PASS="${PASSWORDS[$i]}"
        
        echo "Processing Node $NODE_IP..."
        
        # Check if already joined
        if sshpass -p "$NODE_PASS" ssh -o StrictHostKeyChecking=no "root@$NODE_IP" "test -f /etc/kubernetes/kubelet.conf"; then
            echo "Node $NODE_IP appears to be already joined. Skipping."
        else
            echo "Joining Node $NODE_IP to cluster..."
            
            # Map domain
            sshpass -p "$NODE_PASS" ssh -o StrictHostKeyChecking=no "root@$NODE_IP" "grep -q '$DOMAIN' /etc/hosts || echo '$MASTER_IP $DOMAIN' >> /etc/hosts"
            
            # Join
            sshpass -p "$NODE_PASS" ssh -o StrictHostKeyChecking=no "root@$NODE_IP" "$CLEAN_JOIN_COMMAND"
            
            echo "Node $NODE_IP joined."
        fi
    fi
done

echo "=================================================="
echo "Cluster Deployment Complete!"
echo "Master Node: $MASTER_IP"

# 4. Export Kubeconfig
echo ">>> Phase 4: Exporting Kubeconfig..."
sshpass -p "$MASTER_PASS" scp -o StrictHostKeyChecking=no "root@$MASTER_IP:/etc/kubernetes/admin.conf" ./kubeconfig
echo "Kubeconfig saved to $(pwd)/kubeconfig"

echo "Please verify by running: kubectl --kubeconfig=./kubeconfig get nodes"
echo "Note: You may need to add '$MASTER_IP dotland.fr' to your local /etc/hosts if DNS is not configured."
echo "=================================================="
