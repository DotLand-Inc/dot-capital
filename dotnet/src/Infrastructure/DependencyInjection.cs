using Dotland.DotCapital.WebApi.Application.Common.Interfaces;
using Dotland.DotCapital.WebApi.Infrastructure.Data;
using Dotland.DotCapital.WebApi.Infrastructure.Data.Interceptors;
using Dotland.DotCapital.WebApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Dotland.DotCapital.WebApi.Infrastructure.Identity;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

using System.Data;
using System.Data.Common;


public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Dotland.DotCapital.WebApiDb");
        Guard.Against.Null(connectionString, message: "Connection string 'Dotland.DotCapital.WebApiDb' not found.");

        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        builder.Services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<ITenantService, TenantService>();
        builder.Services.AddScoped<IIdentityService, IdentityService>();

        // System DbContext
        builder.Services.AddDbContext<SystemDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
            Guard.Against.Null(defaultConnection, message: "Connection string 'DefaultConnection' not found.");
            
            options.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection));
        });

        builder.Services.AddScoped<ISystemDbContext>(provider => provider.GetRequiredService<SystemDbContext>());

        // Tenant DbContext
        builder.Services.AddDbContext<TenantDbContext>((sp, options) =>
        {
            var tenantService = sp.GetRequiredService<ITenantService>();
            var tenantConnectionString = tenantService.GetConnectionString();

            if (!string.IsNullOrEmpty(tenantConnectionString))
            {
                options.UseMySql(tenantConnectionString, ServerVersion.AutoDetect(tenantConnectionString));
            }
            // If no tenant is resolved, we might want to throw or allow a specific failure mode.
            // For now, EF will likely throw if initialized without a provider.
        });

        builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<TenantDbContext>());


        builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtSecret = builder.Configuration["Jwt:Secret"];
                Guard.Against.NullOrEmpty(jwtSecret, message: "JWT Secret is not configured");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSecret)),
                    ClockSkew = TimeSpan.Zero,
                    // Match Node.js algorithm
                    ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha384 }
                };

                // Map 'sub' claim to NameIdentifier
                options.MapInboundClaims = false; // Keep original claim types
                options.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Sub;
            });

        builder.Services.AddAuthorizationBuilder();

        builder.Services.AddSingleton(TimeProvider.System);
    }

    public static async Task MigrateAsync(this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        
        var tenantService = scope.ServiceProvider.GetRequiredService<ITenantService>();
        // System Db
        var db = scope.ServiceProvider.GetRequiredService<SystemDbContext>();
        var configuration =  scope.ServiceProvider.GetRequiredService<IConfiguration>();
        
        await BaselineMigration(db, "20260117140348_InitialCreate", "roles");
        await db.Database.MigrateAsync();

        var tenants = db.Tenants.Select(e => e.OrganizationId).ToArray();

        foreach (string? tenant in tenants)
        {
            if(string.IsNullOrEmpty(tenant)) continue;
            var connectionString = tenantService.GetConnectionString(configuration, tenant);
            if(string.IsNullOrEmpty(connectionString)) continue;
            
            var context = TenantDbContext.CreateDbContext(connectionString);
            await BaselineMigration(context, "20260117140354_InitialCreate", "CONTACTS");
            await context.Database.MigrateAsync();
        }
    }

    private static async Task BaselineMigration(DbContext context, string migrationId, string checkTableName)
    {
        var db = context.Database;
        var connection = db.GetDbConnection();
        var dbName = connection.Database;
        const string historyTable = "__EFMigrationsHistory";
        
        // Ensure connection is open
        bool originallyClosed = connection.State != ConnectionState.Open;
        if (originallyClosed)
        {
            await connection.OpenAsync();
        }

        try 
        {
            using var cmd = connection.CreateCommand();

            // 1. Check if the checkTable exists
            cmd.CommandText = $@"
                SELECT COUNT(*) 
                FROM information_schema.tables 
                WHERE table_schema = '{dbName}' 
                AND table_name = '{checkTableName}';";
            
            var tableExists = Convert.ToInt64(await cmd.ExecuteScalarAsync()) > 0;

            if (!tableExists) 
            {
                return;
            }

            // 2. Check if History table exists
            cmd.CommandText = $@"
                SELECT COUNT(*) 
                FROM information_schema.tables 
                WHERE table_schema = '{dbName}' 
                AND table_name = '{historyTable}';";
                
            var historyExists = Convert.ToInt64(await cmd.ExecuteScalarAsync()) > 0;

            if (!historyExists)
            {
                 cmd.CommandText = $@"
                    CREATE TABLE IF NOT EXISTS `{historyTable}` (
                        `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
                        `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
                        PRIMARY KEY (`MigrationId`)
                    ) CHARACTER SET=utf8mb4;";
                 await cmd.ExecuteNonQueryAsync();
            }

            // 3. Check if Migration is already recorded
            cmd.CommandText = $@"
                SELECT COUNT(*) 
                FROM `{historyTable}` 
                WHERE `MigrationId` = '{migrationId}';";
            
            var migrationRecorded = Convert.ToInt64(await cmd.ExecuteScalarAsync()) > 0;

            if (!migrationRecorded)
            {
                Console.WriteLine($"[Migration] Baselining {migrationId} for existing database {dbName}...");
                cmd.CommandText = $@"
                    INSERT INTO `{historyTable}` (`MigrationId`, `ProductVersion`) 
                    VALUES ('{migrationId}', '8.0.2');";
                await cmd.ExecuteNonQueryAsync();
            }
        }
        finally
        {
            if (originallyClosed && connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }
}
