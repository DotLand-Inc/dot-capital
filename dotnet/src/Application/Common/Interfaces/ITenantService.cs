using Microsoft.Extensions.Configuration;

public interface ITenantService
{
    string? GetConnectionString();
    int? GetTenantId();
    string? GetConnectionString(IConfiguration configuration, string organizationId);
}
