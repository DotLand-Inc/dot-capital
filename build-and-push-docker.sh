#!/bin/bash

################################################################################
# Docker Build and Push Script with Automatic Versioning
#
# Description:
#   - Builds all Docker images in the 'docker' folder
#   - Pushes images to hsaii/<image-name>
#   - Checks if tag exists on Docker Hub before pushing
#   - Automatically increments version numbers
#
# Usage:
#   ./build-and-push-docker.sh [--dry-run] [--force]
#
# Options:
#   --dry-run    Show what would be done without actually doing it
#   --force      Push even if tag exists (will overwrite)
################################################################################

set -e  # Exit on error

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

# Configuration
DOCKER_USERNAME="hsaii"
DOCKER_FOLDER="docker"
VERSION_FILE=".docker-versions.json"
DRY_RUN=false
FORCE_PUSH=false

# Parse arguments
while [[ $# -gt 0 ]]; do
  case $1 in
    --dry-run)
      DRY_RUN=true
      shift
      ;;
    --force)
      FORCE_PUSH=true
      shift
      ;;
    *)
      echo -e "${RED}Unknown option: $1${NC}"
      exit 1
      ;;
  esac
done

################################################################################
# Helper Functions
################################################################################

log_info() {
  echo -e "${BLUE}[INFO]${NC} $1"
}

log_success() {
  echo -e "${GREEN}[SUCCESS]${NC} $1"
}

log_warning() {
  echo -e "${YELLOW}[WARNING]${NC} $1"
}

log_error() {
  echo -e "${RED}[ERROR]${NC} $1"
}

# Check if Docker is installed and running
check_docker() {
  if ! command -v docker &> /dev/null; then
    log_error "Docker is not installed"
    exit 1
  fi

  if ! docker info &> /dev/null; then
    log_error "Docker daemon is not running"
    exit 1
  fi
}

# Check if user is logged in to Docker Hub
check_docker_login() {
  log_info "Checking Docker Hub authentication..."
  if ! docker info 2>/dev/null | grep -q "Username: $DOCKER_USERNAME"; then
    log_warning "Not logged in to Docker Hub as $DOCKER_USERNAME"
    log_info "Attempting to login..."
    docker login
  else
    log_success "Already logged in to Docker Hub as $DOCKER_USERNAME"
  fi
}

# Initialize version file if it doesn't exist
init_version_file() {
  if [ ! -f "$VERSION_FILE" ]; then
    log_info "Creating version file: $VERSION_FILE"
    echo "{}" > "$VERSION_FILE"
  fi
}

# Get current version for an image
get_current_version() {
  local image_name=$1

  if [ -f "$VERSION_FILE" ]; then
    local version=$(jq -r ".\"$image_name\" // \"0.0.0\"" "$VERSION_FILE")
    echo "$version"
  else
    echo "0.0.0"
  fi
}

# Increment version (semantic versioning: MAJOR.MINOR.PATCH)
increment_version() {
  local version=$1
  local increment_type=${2:-patch}  # default to patch

  IFS='.' read -r major minor patch <<< "$version"

  case $increment_type in
    major)
      major=$((major + 1))
      minor=0
      patch=0
      ;;
    minor)
      minor=$((minor + 1))
      patch=0
      ;;
    patch|*)
      patch=$((patch + 1))
      ;;
  esac

  echo "$major.$minor.$patch"
}

# Save version to file
save_version() {
  local image_name=$1
  local version=$2

  if ! command -v jq &> /dev/null; then
    log_error "jq is not installed. Please install jq to manage versions."
    exit 1
  fi

  local temp_file=$(mktemp)
  jq --arg name "$image_name" --arg ver "$version" '.[$name] = $ver' "$VERSION_FILE" > "$temp_file"
  mv "$temp_file" "$VERSION_FILE"

  log_success "Saved version $version for $image_name"
}

# Check if tag exists on Docker Hub
tag_exists_on_dockerhub() {
  local image=$1
  local tag=$2

  log_info "Checking if tag exists: $image:$tag"

  # Try to pull the manifest (without downloading the image)
  if docker manifest inspect "$image:$tag" &> /dev/null; then
    return 0  # Tag exists
  else
    return 1  # Tag doesn't exist
  fi
}

# Get all Dockerfiles in the docker folder
find_dockerfiles() {
  if [ ! -d "$DOCKER_FOLDER" ]; then
    log_error "Docker folder '$DOCKER_FOLDER' not found"
    exit 1
  fi

  find "$DOCKER_FOLDER" -name "Dockerfile" -o -name "Dockerfile.*"
}

# Extract image name from Dockerfile path
get_image_name_from_path() {
  local dockerfile_path=$1
  local dir_name=$(dirname "$dockerfile_path")
  local base_name=$(basename "$dir_name")

  # If Dockerfile is directly in docker folder, use Dockerfile name
  if [ "$dir_name" = "$DOCKER_FOLDER" ]; then
    local dockerfile_name=$(basename "$dockerfile_path")
    if [ "$dockerfile_name" = "Dockerfile" ]; then
      base_name="app"
    else
      # Extract name from Dockerfile.name pattern
      base_name=$(echo "$dockerfile_name" | sed 's/Dockerfile\.//')
    fi
  fi

  echo "$base_name"
}

# Build Docker image
build_image() {
  local dockerfile_path=$1
  local image_name=$2
  local version=$3
  local build_context=$(dirname "$dockerfile_path")

  local full_image_name="${DOCKER_USERNAME}/${image_name}:${version}"
  local latest_tag="${DOCKER_USERNAME}/${image_name}:latest"

  log_info "Building image: $full_image_name"
  log_info "Build context: $build_context"
  log_info "Dockerfile: $dockerfile_path"

  if [ "$DRY_RUN" = true ]; then
    log_warning "[DRY RUN] Would build: $full_image_name"
    return 0
  fi

  # Build with both version tag and latest tag
  if docker build -t "$full_image_name" -t "$latest_tag" -f "$dockerfile_path" "$build_context"; then
    log_success "Successfully built: $full_image_name"
    return 0
  else
    log_error "Failed to build: $full_image_name"
    return 1
  fi
}

# Push Docker image
push_image() {
  local image_name=$1
  local version=$2

  local full_image_name="${DOCKER_USERNAME}/${image_name}:${version}"
  local latest_tag="${DOCKER_USERNAME}/${image_name}:latest"

  # Check if tag already exists
  if tag_exists_on_dockerhub "${DOCKER_USERNAME}/${image_name}" "$version"; then
    if [ "$FORCE_PUSH" = true ]; then
      log_warning "Tag exists but --force flag is set. Pushing anyway..."
    else
      log_warning "Tag $version already exists for $image_name. Skipping push."
      log_info "Use --force to override or increment version manually."
      return 2  # Special return code for "already exists"
    fi
  fi

  if [ "$DRY_RUN" = true ]; then
    log_warning "[DRY RUN] Would push: $full_image_name"
    log_warning "[DRY RUN] Would push: $latest_tag"
    return 0
  fi

  log_info "Pushing image: $full_image_name"
  if docker push "$full_image_name"; then
    log_success "Successfully pushed: $full_image_name"
  else
    log_error "Failed to push: $full_image_name"
    return 1
  fi

  log_info "Pushing latest tag: $latest_tag"
  if docker push "$latest_tag"; then
    log_success "Successfully pushed: $latest_tag"
  else
    log_error "Failed to push: $latest_tag"
    return 1
  fi

  return 0
}

################################################################################
# Main Script
################################################################################

main() {
  echo "=================================="
  echo "Docker Build and Push Script"
  echo "=================================="
  echo ""

  # Preliminary checks
  check_docker
  init_version_file

  if [ "$DRY_RUN" = false ]; then
    check_docker_login
  else
    log_warning "Running in DRY RUN mode - no actual builds or pushes will occur"
  fi

  # Find all Dockerfiles
  log_info "Scanning for Dockerfiles in '$DOCKER_FOLDER'..."

  dockerfiles=$(find_dockerfiles)

  if [ -z "$dockerfiles" ]; then
    log_error "No Dockerfiles found in '$DOCKER_FOLDER'"
    exit 1
  fi

  dockerfile_count=$(echo "$dockerfiles" | wc -l)
  log_success "Found $dockerfile_count Dockerfile(s)"
  echo ""

  # Process each Dockerfile
  local success_count=0
  local skip_count=0
  local fail_count=0

  while IFS= read -r dockerfile; do
    echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"

    # Get image name from path
    image_name=$(get_image_name_from_path "$dockerfile")
    log_info "Processing: $image_name"
    log_info "Dockerfile: $dockerfile"

    # Get current version and increment
    current_version=$(get_current_version "$image_name")
    new_version=$(increment_version "$current_version" "patch")

    log_info "Current version: $current_version"
    log_info "New version: $new_version"
    echo ""

    # Build image
    if build_image "$dockerfile" "$image_name" "$new_version"; then
      echo ""

      # Push image
      push_result=0
      push_image "$image_name" "$new_version" || push_result=$?

      if [ $push_result -eq 0 ]; then
        # Save new version only if push was successful
        if [ "$DRY_RUN" = false ]; then
          save_version "$image_name" "$new_version"
        fi
        success_count=$((success_count + 1))
      elif [ $push_result -eq 2 ]; then
        # Tag already exists
        skip_count=$((skip_count + 1))
      else
        # Push failed
        fail_count=$((fail_count + 1))
      fi
    else
      log_error "Build failed for $image_name"
      fail_count=$((fail_count + 1))
    fi

    echo ""
  done <<< "$dockerfiles"

  # Summary
  echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
  echo "Summary"
  echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
  log_success "Successful: $success_count"
  if [ $skip_count -gt 0 ]; then
    log_warning "Skipped (tag exists): $skip_count"
  fi
  if [ $fail_count -gt 0 ]; then
    log_error "Failed: $fail_count"
  fi
  echo ""

  if [ $fail_count -gt 0 ]; then
    exit 1
  fi
}

# Run main function
main
