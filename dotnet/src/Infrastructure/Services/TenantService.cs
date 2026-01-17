using Dotland.DotCapital.WebApi.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Dotland.DotCapital.WebApi.Infrastructure.Services;

public class TenantService : ITenantService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SystemDbContext _systemDbContext;
    private readonly IConfiguration _configuration;

    public TenantService(
        IHttpContextAccessor httpContextAccessor, 
        SystemDbContext systemDbContext,
        IConfiguration configuration)
    {
        _httpContextAccessor = httpContextAccessor;
        _systemDbContext = systemDbContext;
        _configuration = configuration;
    }

    public int? GetTenantId()
    {
        var context = _httpContextAccessor.HttpContext;
        if (context == null) return null;

        if (context.Request.Headers.TryGetValue("organization-id", out var organizationIdValues))
        {
            var organizationId = organizationIdValues.ToString();
            
            // Query System DB to find tenant (Sync)
            var tenant = _systemDbContext.Tenants
                .AsNoTracking()
                .FirstOrDefault(t => t.OrganizationId == organizationId);

            return tenant?.Id;
        }

        return null;
    }

    public string? GetConnectionString()
    {
        var context = _httpContextAccessor.HttpContext;
        if (context == null) return null;

        if (context.Request.Headers.TryGetValue("organization-id", out var organizationIdValues))
        {
            var organizationId = organizationIdValues.ToString();
            
            // Verify tenant exists (optional but good for consistency) and get necessary details if logic requires more than just the ID
            // For now, based on instructions, we can assume the DB name follows the org ID.
            // But strictness suggests we should verify it exists in System DB first.
            
            var tenantExists = _systemDbContext.Tenants
                .AsNoTracking()
                .Any(t => t.OrganizationId == organizationId);

            if (!tenantExists) return null;

            // Construct connection string
            var systemConnectionString = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(systemConnectionString)) return null;

            var builder = new MySqlConnectionStringBuilder(systemConnectionString)
            {
                Database = $"bigcapital_tenant_{organizationId}"
            };

            return builder.ConnectionString;
        }

        return null;
    }
}
