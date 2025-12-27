#!/bin/bash

# Script to Secure Longhorn Ingress with Basic Auth
# Usage: ./setup_longhorn_auth.sh [username] [password]

set -e

# Check for environment variables or arguments
USERNAME="${1:-${LONGHORN_USER}}"
PASSWORD="${2:-${LONGHORN_PASS}}"

if [[ -z "$USERNAME" || -z "$PASSWORD" ]]; then
    echo "Error: Credentials not provided."
    echo "Usage: $0 [username] [password] OR set LONGHORN_USER and LONGHORN_PASS env vars"
    exit 1
fi
NAMESPACE="longhorn-system"
SECRET_NAME="longhorn-auth"

echo ">>> Setting up Basic Auth for Longhorn..."
echo "User: $USERNAME"
echo "Pass: (hidden)"
echo "Target Secret: $SECRET_NAME ($NAMESPACE)"

# 1. Generate htpasswd content using openssl
# Used -apr1 (MD5-based) which is widely supported by Nginx Basic Auth
echo ">>> Generating password hash..."
HASH=$(openssl passwd -apr1 "$PASSWORD")
HTPASSWD_CONTENT="${USERNAME}:${HASH}"

# 2. Create/Update Secret
echo ">>> Updating Secret..."
# Save to a temporary file correctly
echo "$HTPASSWD_CONTENT" > auth

kubectl --kubeconfig=./kubeconfig create secret generic "$SECRET_NAME" \
    --from-file=auth \
    -n "$NAMESPACE" \
    --dry-run=client -o yaml | kubectl --kubeconfig=./kubeconfig apply -f -

rm auth

# 3. Patch Ingress
echo ">>> Patching Ingress to enforce Authentication..."
kubectl --kubeconfig=./kubeconfig -n "$NAMESPACE" patch ingress longhorn-ingress --type='json' -p='[
    {"op": "add", "path": "/metadata/annotations/nginx.ingress.kubernetes.io~1auth-type", "value": "basic"},
    {"op": "add", "path": "/metadata/annotations/nginx.ingress.kubernetes.io~1auth-secret", "value": "'"$SECRET_NAME"'"},
    {"op": "add", "path": "/metadata/annotations/nginx.ingress.kubernetes.io~1auth-realm", "value": "Authentication Required"}
]'

echo "=================================================="
echo "Basic Authentication Enabled!"
echo "User: $USERNAME"
echo "Pass: $PASSWORD (Change this ASAP via script if default)"
echo "Access: https://longhorn.dotland.fr"
echo "=================================================="
