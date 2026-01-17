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

namespace Microsoft.Extensions.DependencyInjection;

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

        // System DbContext
        builder.Services.AddDbContext<SystemDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");
            
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        builder.Services.AddScoped<ISystemDbContext>(provider => provider.GetRequiredService<SystemDbContext>());

        // Tenant DbContext
        builder.Services.AddDbContext<TenantDbContext>((sp, options) =>
        {
            var tenantService = sp.GetRequiredService<ITenantService>();
            var connectionString = tenantService.GetConnectionString();

            if (!string.IsNullOrEmpty(connectionString))
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            // If no tenant is resolved, we might want to throw or allow a specific failure mode.
            // For now, EF will likely throw if initialized without a provider.
        });


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
}
