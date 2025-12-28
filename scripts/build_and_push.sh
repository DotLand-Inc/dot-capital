#!/bin/bash

# Exit on error
set -e

# Load version
VERSION=$(cat ../VERSION)
echo "Building version: $VERSION"

# Build and Push Server
echo "Building Server..."
docker build -t hsaii/server:$VERSION -t hsaii/server:latest -f ../packages/server/Dockerfile ../
docker push hsaii/server:$VERSION
docker push hsaii/server:latest

# Build and Push Webapp
echo "Building Webapp..."
docker build -t hsaii/webapp:$VERSION -t hsaii/webapp:latest -f ../packages/webapp/Dockerfile ../
docker push hsaii/webapp:$VERSION
docker push hsaii/webapp:latest

# Build and Push Migration
echo "Building Migration..."
docker build -t hsaii/migration:$VERSION -t hsaii/migration:latest -f ../docker/migration/Dockerfile ../
docker push hsaii/migration:$VERSION
docker push hsaii/migration:latest

echo "All images built and pushed successfully!"
