#!/bin/bash

# Script to Import a Custom/Paid Certificate
# Usage: ./import_custom_cert.sh <cert_file> <key_file> [secret_name] [namespace]

set -e

CERT_FILE="$1"
KEY_FILE="$2"
SECRET_NAME="${3:-longhorn-tls}"
NAMESPACE="${4:-longhorn-system}"

if [[ -z "$CERT_FILE" || -z "$KEY_FILE" ]]; then
    echo "Usage: $0 <cert_file> <key_file> [secret_name] [namespace]"
    echo "Example: $0 my_domain.crt my_domain.key longhorn-tls longhorn-system"
    exit 1
fi

if [[ ! -f "$CERT_FILE" ]]; then
    echo "Error: Certificate file '$CERT_FILE' not found."
    exit 1
fi

if [[ ! -f "$KEY_FILE" ]]; then
    echo "Error: Key file '$KEY_FILE' not found."
    exit 1
fi

echo "=================================================="
echo "Importing Custom Certificate"
echo "Target Secret:    $SECRET_NAME"
echo "Target Namespace: $NAMESPACE"
echo "=================================================="

# 1. Check for conflicting Cert-Manager Certificate resources
# If cert-manager is managing this secret, it might overwrite our custom details.
# We need to find and delete the 'Certificate' object pointing to this secret.
echo ">>> Checking for conflicting Cert-Manager resources..."
CONFLICTING_CERT=$(kubectl get certificate -n "$NAMESPACE" -o jsonpath="{.items[?(@.spec.secretName=='$SECRET_NAME')].metadata.name}" 2>/dev/null || true)

if [[ -n "$CONFLICTING_CERT" ]]; then
    echo "WARNING: Found a cert-manager Certificate resource named '$CONFLICTING_CERT' managing this secret."
    echo "If we don't remove it, cert-manager might overwrite your custom certificate later."
    read -p "Do you want to delete this Cert-Manager resource to permanently switch to your custom cert? (y/n) " -n 1 -r
    echo
    if [[ $REPLY =~ ^[Yy]$ ]]; then
        kubectl delete certificate "$CONFLICTING_CERT" -n "$NAMESPACE"
        echo "Deleted conflicting Certificate resource."
    else
        echo "Aborting import to prevent conflict."
        exit 1
    fi
else
    echo "No conflicts found."
fi

# 2. Create/Update the Secret
echo ">>> Updating TLS Secret..."
kubectl create secret tls "$SECRET_NAME" \
    --cert="$CERT_FILE" \
    --key="$KEY_FILE" \
    -n "$NAMESPACE" \
    --dry-run=client -o yaml | kubectl apply -f -

echo "=================================================="
echo "Success! Custom certificate has been applied."
echo "Your Ingress controller should pick up the change immediately."
echo "=================================================="
