using Dotland.DotCapital.WebApi.Infrastructure.Identity;

namespace Dotland.DotCapital.WebApi.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapIdentityApi<ApplicationUser>();
    }
}
