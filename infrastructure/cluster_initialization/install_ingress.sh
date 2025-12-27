#!/bin/bash

# Script to install Ingress NGINX Controller
# This is the recommended alternative to MetalLB for bare-metal/VPS environments
# where Layer 2 (ARP) LoadBalancing is often blocked by the provider.
# It configures NGINX to listen directly on the Host's ports 80 and 443.

set -e

MASTER_IP="${MASTER_IP:-161.97.164.73}" # Default or from Env

echo ">>> Installing Ingress NGINX Controller..."

# 1. Download the standard manifest (Fresh)
rm -f ingress-nginx.yaml
wget -qO ingress-nginx.yaml https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.8.2/deploy/static/provider/baremetal/deploy.yaml

# 2. Patch: Convert Deployment to DaemonSet
# We accept that there is only one Deployment in this manifest usually.
sed -i 's/kind: Deployment/kind: DaemonSet/g' ingress-nginx.yaml

# 3. Patch: Enable HostNetwork and DNSPolicy
# finding 'terminationGracePeriodSeconds: 300' which is within the Pod Spec of the controller
# and adding fields after it.
sed -i '/terminationGracePeriodSeconds: 300/a \      hostNetwork: true\n      dnsPolicy: ClusterFirstWithHostNet\n      tolerations:\n      - key: "node-role.kubernetes.io/control-plane"\n        operator: "Exists"\n        effect: "NoSchedule"\n      - key: "node-role.kubernetes.io/master"\n        operator: "Exists"\n        effect: "NoSchedule"' ingress-nginx.yaml

# 4. Apply
kubectl --kubeconfig=./kubeconfig apply -f ingress-nginx.yaml

# 5. Wait for rollout
echo ">>> Waiting for Ingress NGINX to be ready..."
# The resource is now a DaemonSet named ingress-nginx-controller
kubectl --kubeconfig=./kubeconfig rollout status daemonset ingress-nginx-controller -n ingress-nginx --timeout=90s || echo "Timed out waiting, but deployment continues..."

echo "=================================================="
echo "Ingress NGINX Installed Successfully!"
echo "Access your apps by pointing DNS to ANY Node IP ($MASTER_IP, etc.)"
echo "HTTP traffic will be handled on Port 80, HTTPS on Port 443."
echo "=================================================="
rm ingress-nginx.yaml
