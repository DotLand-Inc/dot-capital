#!/bin/bash

# Kubernetes Bootstrap Script for Ubunutu 20.04/22.04
# Installs Containerd, Kubelet, Kubeadm, Kubectl

set -e

echo "[TASK 1] Disable and turn off SWAP"
sed -i '/swap/d' /etc/fstab
swapoff -a

echo "[TASK 2] Stop and Disable firewall"
systemctl disable --now ufw >/dev/null 2>&1

echo "[TASK 3] Enable and Load Kernel modules"
cat <<EOF | tee /etc/modules-load.d/k8s.conf
overlay
br_netfilter
EOF

modprobe overlay
modprobe br_netfilter

echo "[TASK 4] Add Kernel settings"
cat <<EOF | tee /etc/sysctl.d/k8s.conf
net.bridge.bridge-nf-call-iptables  = 1
net.bridge.bridge-nf-call-ip6tables = 1
net.ipv4.ip_forward                 = 1
EOF

sysctl --system >/dev/null 2>&1

echo "[TASK 5] Install Containerd Runtime"
if ! command -v containerd &> /dev/null; then
    apt-get update >/dev/null 2>&1
    apt-get install -y ca-certificates curl gnupg lsb-release >/dev/null 2>&1

    mkdir -p /etc/apt/keyrings
    curl -fsSL https://download.docker.com/linux/ubuntu/gpg | gpg --batch --yes --dearmor -o /etc/apt/keyrings/docker.gpg

    echo \
      "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu \
      $(lsb_release -cs) stable" | tee /etc/apt/sources.list.d/docker.list > /dev/null

    apt-get update >/dev/null 2>&1
    apt-get install -y containerd.io >/dev/null 2>&1

    containerd config default > /etc/containerd/config.toml
    sed -i 's/SystemdCgroup = false/SystemdCgroup = true/g' /etc/containerd/config.toml

    systemctl restart containerd
    systemctl enable containerd >/dev/null 2>&1
else
    echo "Containerd already installed. Skipping."
fi

echo "[TASK 6] Add Apt repository for Kubernetes"
if [ ! -f /etc/apt/sources.list.d/kubernetes.list ]; then
    curl -fsSL https://pkgs.k8s.io/core:/stable:/v1.29/deb/Release.key | gpg --batch --yes --dearmor -o /etc/apt/keyrings/kubernetes-apt-keyring.gpg
    echo 'deb [signed-by=/etc/apt/keyrings/kubernetes-apt-keyring.gpg] https://pkgs.k8s.io/core:/stable:/v1.29/deb/ /' | tee /etc/apt/sources.list.d/kubernetes.list
fi

echo "[TASK 7] Install Kubernetes tools"
if ! command -v kubeadm &> /dev/null; then
    apt-get update >/dev/null 2>&1
    apt-get install -y kubelet kubeadm kubectl >/dev/null 2>&1
    apt-mark hold kubelet kubeadm kubectl >/dev/null 2>&1
else
    echo "Kubernetes tools already installed. Skipping."
fi

echo "[TASK 8] Enable ssh password authentication"
sed -i 's/^PasswordAuthentication .*/PasswordAuthentication yes/' /etc/ssh/sshd_config
# Also ensure PermitRootLogin is yes if we are using root
sed -i 's/^#PermitRootLogin .*/PermitRootLogin yes/' /etc/ssh/sshd_config
sed -i 's/^PermitRootLogin .*/PermitRootLogin yes/' /etc/ssh/sshd_config
systemctl reload ssh

echo "[TASK 9] Install sshpass on nodes (useful for inter-node ops if needed)"
apt-get install -y sshpass >/dev/null 2>&1

echo "Bootstrap complete!"
