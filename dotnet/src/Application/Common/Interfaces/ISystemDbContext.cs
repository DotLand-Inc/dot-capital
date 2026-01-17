namespace Dotland.DotCapital.WebApi.Application.Common.Interfaces;

public interface ISystemDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
