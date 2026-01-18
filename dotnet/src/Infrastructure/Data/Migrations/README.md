# Database Migrations

This project uses Entity Framework Core with MySQL (Pomelo provider) for database management.

## Database Architecture

The application uses a two-database multi-tenant architecture:

| Database | Context | Purpose |
|----------|---------|---------|
| `dotcapital_system` | `SystemDbContext` | System users, tenants, subscriptions |
| `dotcapital_tenant_{orgId}` | `TenantDbContext` | Tenant-specific business data |

## Prerequisites

- .NET 10 SDK
- MySQL 8.0+
- EF Core CLI tools (`dotnet tool install --global dotnet-ef`)

## Connection Strings

Configure in `appsettings.json` or `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=dotcapital_system;User=root;Password=yourpassword;SslMode=None;",
    "TenantConnection": "Server=localhost;Port=3306;Database=dotcapital_tenant_template;User=root;Password=yourpassword;SslMode=None;"
  }
}
```

## Applying Migrations

Run commands from the solution root (`/dotnet`):

```bash
# Apply System database migration
dotnet ef database update --context SystemDbContext --project src/Infrastructure --startup-project src/Web

# Apply Tenant database migration (for template/new tenants)
dotnet ef database update --context TenantDbContext --project src/Infrastructure --startup-project src/Web
```

## Creating New Migrations

When you modify entity classes, create a new migration:

```bash
# For SystemDbContext changes
dotnet ef migrations add <MigrationName> --context SystemDbContext --output-dir Data/Migrations/System --project src/Infrastructure --startup-project src/Web

# For TenantDbContext changes
dotnet ef migrations add <MigrationName> --context TenantDbContext --output-dir Data/Migrations/Tenant --project src/Infrastructure --startup-project src/Web
```

## Removing Last Migration

If you need to undo the last migration (before applying to database):

```bash
# Remove last SystemDbContext migration
dotnet ef migrations remove --context SystemDbContext --project src/Infrastructure --startup-project src/Web

# Remove last TenantDbContext migration
dotnet ef migrations remove --context TenantDbContext --project src/Infrastructure --startup-project src/Web
```

## Generating SQL Scripts

To generate SQL scripts instead of applying directly:

```bash
# Generate System database script
dotnet ef migrations script --context SystemDbContext --project src/Infrastructure --startup-project src/Web -o system_migration.sql

# Generate Tenant database script
dotnet ef migrations script --context TenantDbContext --project src/Infrastructure --startup-project src/Web -o tenant_migration.sql
```

## Reverting Migrations

To revert to a specific migration:

```bash
# Revert SystemDbContext to specific migration
dotnet ef database update <MigrationName> --context SystemDbContext --project src/Infrastructure --startup-project src/Web

# Revert to initial state (before any migrations)
dotnet ef database update 0 --context SystemDbContext --project src/Infrastructure --startup-project src/Web
```

## Notes

- The `ArtifactsPath` in `Directory.Build.props` may need to be temporarily commented out when running EF commands due to a known issue with custom output paths.
- The design-time factories in `DesignTimeDbContextFactory.cs` use MySQL 8.0.36 as the target version. Update if your MySQL version differs significantly.
- For multi-tenant databases, each tenant gets a separate database named `dotcapital_tenant_{organizationId}`.
