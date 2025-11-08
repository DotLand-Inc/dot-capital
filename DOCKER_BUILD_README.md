# Docker Build and Push Script

Automated script for building and pushing Docker images with version management.

## Features

- ✅ **Automatic Version Management**: Incremental semantic versioning (MAJOR.MINOR.PATCH)
- ✅ **Tag Existence Check**: Prevents overwriting existing tags on Docker Hub
- ✅ **Multi-Image Support**: Builds all Dockerfiles in the `docker/` folder
- ✅ **Dry Run Mode**: Test without actually building or pushing
- ✅ **Force Push Option**: Override existing tags if needed
- ✅ **Color-Coded Output**: Easy-to-read console output
- ✅ **Latest Tag**: Automatically tags and pushes with `latest`
- ✅ **Isolated Builds**: Only processes `docker/` folder, ignores `packages/`

## Images Built by This Script

This script builds the following infrastructure images from the `docker/` folder:

| Image | Description | Base Image |
|-------|-------------|------------|
| **hsaii/mariadb** | Custom MariaDB with initialization scripts and custom config | `mariadb:10.2` |
| **hsaii/redis** | Redis with custom configuration | `redis:6.2.0` |
| **hsaii/migration** | Database migration service (runs migrations on startup) | `bigcapitalhq/server:latest` |
| **hsaii/mongo** | MongoDB database | `mongo:5.0` |

**Note**: Application images (`webapp`, `server`) are **NOT** built by this script. They remain in the `packages/` folder.

## Prerequisites

### Required Tools

```bash
# Docker (required)
docker --version

# jq (required for version management)
sudo apt-get install jq  # Ubuntu/Debian
brew install jq          # macOS
```

### Docker Hub Authentication

Login to Docker Hub before running the script:

```bash
docker login
# Enter username: hsaii
# Enter password: <your-token-or-password>
```

## Usage

### Basic Usage

Build and push all Docker images:

```bash
./build-and-push-docker.sh
```

### Dry Run Mode

Test without actually building or pushing:

```bash
./build-and-push-docker.sh --dry-run
```

### Force Push

Override existing tags (use with caution):

```bash
./build-and-push-docker.sh --force
```

## Directory Structure

The script scans **ONLY** the `docker/` folder at the root of the project. It ignores all other directories like `packages/`.

### Current Project Structure

```
docker/
├── mariadb/
│   ├── Dockerfile
│   ├── my.cnf
│   ├── init.sql
│   └── docker-entrypoint.sh
├── redis/
│   ├── Dockerfile
│   └── redis.conf
├── migration/
│   └── Dockerfile
├── mongo/
│   └── Dockerfile
└── envoy/
    └── envoy.yaml (no Dockerfile - ignored)
```

**Result**: The following images will be built and pushed:
- `hsaii/mariadb:0.0.1` + `hsaii/mariadb:latest`
- `hsaii/redis:0.0.1` + `hsaii/redis:latest`
- `hsaii/migration:0.0.1` + `hsaii/migration:latest`
- `hsaii/mongo:0.0.1` + `hsaii/mongo:latest`

### What is Ignored

The script **ONLY** processes Dockerfiles in the `docker/` folder. Everything else is ignored:

```
❌ packages/webapp/Dockerfile    → IGNORED
❌ packages/server/Dockerfile    → IGNORED
❌ Any other Dockerfiles outside docker/ → IGNORED
```

## Version Management

### Version File

Versions are stored in `.docker-versions.json`:

```json
{
  "mariadb": "0.0.5",
  "redis": "0.1.2",
  "migration": "0.0.3",
  "mongo": "1.0.0"
}
```

### Semantic Versioning

The script uses semantic versioning (MAJOR.MINOR.PATCH):

- **PATCH** (0.0.X): Bug fixes, small changes (default increment)
- **MINOR** (0.X.0): New features, backward compatible
- **MAJOR** (X.0.0): Breaking changes

### Manual Version Editing

You can manually edit `.docker-versions.json` to set specific versions:

```json
{
  "mariadb": "1.0.0",
  "redis": "2.5.3",
  "migration": "0.1.0",
  "mongo": "1.2.0"
}
```

The script will increment from your specified version.

## How It Works

### Workflow

1. **Scan**: Finds all Dockerfiles in `docker/` folder
2. **Version Check**: Reads current version from `.docker-versions.json`
3. **Increment**: Automatically increments patch version (e.g., 0.0.1 → 0.0.2)
4. **Tag Check**: Verifies if tag exists on Docker Hub
5. **Build**: Builds image with new version tag and `latest` tag
6. **Push**: Pushes both tags to Docker Hub (if tag doesn't exist)
7. **Save**: Updates version in `.docker-versions.json`

### Tag Existence Check

Before pushing, the script checks if the tag already exists on Docker Hub:

- **Exists + No Force**: Skips push, shows warning
- **Exists + Force Flag**: Pushes anyway (overwrites)
- **Doesn't Exist**: Pushes normally

## Examples

### Example 1: First Run

```bash
$ ./build-and-push-docker.sh

[INFO] Found 4 Dockerfile(s)

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
[INFO] Processing: mariadb
[INFO] Current version: 0.0.0
[INFO] New version: 0.0.1
[INFO] Building image: hsaii/mariadb:0.0.1
[SUCCESS] Successfully built: hsaii/mariadb:0.0.1
[INFO] Pushing image: hsaii/mariadb:0.0.1
[SUCCESS] Successfully pushed: hsaii/mariadb:0.0.1
[SUCCESS] Successfully pushed: hsaii/mariadb:latest

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
[INFO] Processing: redis
[INFO] Current version: 0.0.0
[INFO] New version: 0.0.1
...

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
Summary
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
[SUCCESS] Successful: 4
```

### Example 2: Tag Already Exists

```bash
$ ./build-and-push-docker.sh

[WARNING] Tag 0.0.1 already exists for mariadb. Skipping push.
[INFO] Use --force to override or increment version manually.
```

### Example 3: Dry Run

```bash
$ ./build-and-push-docker.sh --dry-run

[WARNING] Running in DRY RUN mode - no actual builds or pushes will occur
[INFO] Found 4 Dockerfile(s)
[DRY RUN] Would build: hsaii/mariadb:0.0.2
[DRY RUN] Would push: hsaii/mariadb:0.0.2
[DRY RUN] Would push: hsaii/mariadb:latest
...
```

## Troubleshooting

### Error: "Docker daemon is not running"

```bash
# Start Docker
sudo systemctl start docker  # Linux
# or open Docker Desktop       # macOS/Windows
```

### Error: "jq is not installed"

```bash
# Install jq
sudo apt-get install jq      # Ubuntu/Debian
brew install jq              # macOS
```

### Error: "Not logged in to Docker Hub"

```bash
docker login
# Enter credentials for hsaii account
```

### Tag Already Exists (and you want to push)

Use the `--force` flag:

```bash
./build-and-push-docker.sh --force
```

### Reset Versions

Delete `.docker-versions.json` to start from scratch:

```bash
rm .docker-versions.json
./build-and-push-docker.sh
```

## Advanced Usage

### Bump Major or Minor Version

Edit `.docker-versions.json` manually:

```json
{
  "mariadb": "1.0.0",    // Changed from 0.0.5
  "redis": "0.1.0",      // Changed from 0.0.8
  "migration": "2.0.0",  // Changed from 1.5.3
  "mongo": "0.5.0"       // Changed from 0.4.2
}
```

Next run will increment to `1.0.1`, `0.1.1`, `2.0.1`, and `0.5.1` respectively.

### Build Specific Image

Currently, the script builds all images. To build only a specific image, temporarily move others:

```bash
# Example: Build only mariadb
mkdir temp_docker
mv docker/redis docker/migration docker/mongo temp_docker/
./build-and-push-docker.sh

# Restore
mv temp_docker/* docker/
rmdir temp_docker
```

Or use Docker directly for a single image:

```bash
# Build and push only mariadb
cd docker/mariadb
docker build -t hsaii/mariadb:0.0.5 -t hsaii/mariadb:latest .
docker push hsaii/mariadb:0.0.5
docker push hsaii/mariadb:latest
```

### Custom Docker Registry

To use a different registry (not Docker Hub), edit the script:

```bash
# Change this line in the script:
DOCKER_USERNAME="hsaii"
# To:
DOCKER_USERNAME="your-registry.com/hsaii"
```

## Version File Format

`.docker-versions.json` structure:

```json
{
  "image-name-1": "version-string",
  "image-name-2": "version-string"
}
```

Example:

```json
{
  "mariadb": "2.1.5",
  "redis": "1.0.3",
  "migration": "0.5.1",
  "mongo": "3.2.0"
}
```

## Best Practices

1. **Use Git Tags**: Tag your Git commits to match Docker image versions
   ```bash
   git tag -a v0.0.1 -m "Release 0.0.1"
   git push origin v0.0.1
   ```

2. **Dry Run First**: Always test with `--dry-run` before actual push

3. **Commit Version File**: Track `.docker-versions.json` in Git

4. **Use Force Sparingly**: Only use `--force` when absolutely necessary

5. **Document Breaking Changes**: When bumping major versions, document changes

## CI/CD Integration

### GitHub Actions

```yaml
name: Build and Push Docker Images

on:
  push:
    branches: [main]

jobs:
  docker:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3

      - name: Login to Docker Hub
        uses: docker/login-action@v2
        with:
          username: hsaii
          password: ${{ secrets.DOCKERHUB_TOKEN }}

      - name: Build and Push
        run: ./build-and-push-docker.sh
```

### GitLab CI

```yaml
docker-build:
  image: docker:latest
  services:
    - docker:dind
  script:
    - docker login -u hsaii -p $DOCKERHUB_TOKEN
    - ./build-and-push-docker.sh
```

## License

This script is part of the dot-capital project by dotland.
