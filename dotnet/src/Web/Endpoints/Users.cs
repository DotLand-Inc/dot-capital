using Dotland.DotCapital.WebApi.Infrastructure.Identity;

namespace Dotland.DotCapital.WebApi.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        // Removed Identity API endpoints - authentication handled by Node.js service
        // groupBuilder.MapIdentityApi<ApplicationUser>();
    }
}
