FROM node:18.16.0-alpine

USER root

WORKDIR /app

# Copy application dependency manifests to the container image.
COPY . .

# Install application dependencies
RUN apk update
RUN apk add python3 build-base chromium

# Set PYHTON env
ENV PYTHON=/usr/bin/python3

# Install pnpm packages dependencies
RUN npm install -g pnpm
RUN pnpm install

# Build server package
RUN pnpm run build:server

# Expose port (default NestJS)
EXPOSE 3000

# Start server
CMD ["node", "packages/server/dist/main"]
