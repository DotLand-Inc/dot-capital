using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dotland.DotCapital.WebApi.Infrastructure.Data;

public class SystemDbContextFactory : IDesignTimeDbContextFactory<SystemDbContext>
{
    public SystemDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Web"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<SystemDbContext>();
        // Use a fixed MySQL version to avoid connecting to the database during design-time
        optionsBuilder.UseMySql(connectionString!, new MySqlServerVersion(new Version(8, 0, 36)));

        return new SystemDbContext(optionsBuilder.Options);
    }
}

public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
{
    public TenantDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Web"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("TenantConnection");

        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        // Use a fixed MySQL version to avoid connecting to the database during design-time
        optionsBuilder.UseMySql(connectionString!, new MySqlServerVersion(new Version(8, 0, 36)));

        return new TenantDbContext(optionsBuilder.Options);
    }
    
    
}
