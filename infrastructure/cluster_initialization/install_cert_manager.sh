#!/bin/bash

# Script to install cert-manager
set -e


CERT_MANAGER_VERSION="v1.13.3"

echo ">>> Installing cert-manager ${CERT_MANAGER_VERSION}..."

# Install via Manifest (includes CRDs)
# 'kubectl apply' is idempotent: running this again will update existing resources
# without deleting them, preserving current certificates.
kubectl apply -f https://github.com/cert-manager/cert-manager/releases/download/${CERT_MANAGER_VERSION}/cert-manager.yaml

echo ">>> Waiting for cert-manager pods to be ready..."
# Wait for the webhook to be active (critical for creating Issuers)
kubectl rollout status deployment/cert-manager-webhook -n cert-manager --timeout=300s

echo ">>> cert-manager installed!"
echo "Note: cert-manager automatically renews certificates 30 days before expiry."
echo "To force renewal, you can delete the certificate secret."

