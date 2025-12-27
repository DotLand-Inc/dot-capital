#!/bin/bash

# Script to install Longhorn Storage via Manifest (No Helm required)
set -e

LONGHORN_VERSION="v1.7.2"

echo ">>> Installing Longhorn $LONGHORN_VERSION via Manifest..."

# 1. Install Longhorn
kubectl apply -f https://raw.githubusercontent.com/longhorn/longhorn/${LONGHORN_VERSION}/deploy/longhorn.yaml

echo ">>> Waiting for Longhorn pods to be ready..."
# Wait for one of the key deployments
kubectl rollout status deployment/longhorn-driver-deployer -n longhorn-system --timeout=300s

echo ">>> Creating Ingress for Longhorn Dashboard..."
cat <<EOF | kubectl apply -f -
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: longhorn-ingress
  namespace: longhorn-system
  annotations:
    nginx.ingress.kubernetes.io/ssl-redirect: "true"
    nginx.ingress.kubernetes.io/proxy-body-size: "100m"
    cert-manager.io/cluster-issuer: "letsencrypt-prod"
spec:
  ingressClassName: nginx
  tls:
  - hosts:
    - longhorn.dotland.fr
    secretName: longhorn-tls
  rules:
  - host: longhorn.dotland.fr
    http:
      paths:
      - path: /
        pathType: Prefix
        backend:
          service:
            name: longhorn-frontend
            port:
              number: 80
EOF

echo "=================================================="
echo "Longhorn Installed Successfully!"
echo "UI Access: http://longhorn.dotland.fr"
echo "Note: Ensure 'open-iscsi' and 'nfs-common' are installed on all nodes."
echo "=================================================="
