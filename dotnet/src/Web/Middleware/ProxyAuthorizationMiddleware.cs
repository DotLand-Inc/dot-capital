namespace Dotland.DotCapital.WebApi.Web.Middleware;

public class ProxyAuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public ProxyAuthorizationMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value ?? string.Empty;
        var publicRoutes = _configuration.GetSection("PublicRoutes").Get<List<string>>() ?? new List<string>();

        // Check if path starts with any public route
        var isPublicRoute = publicRoutes.Any(route =>
            path.StartsWith(route, StringComparison.OrdinalIgnoreCase));

        if (!isPublicRoute)
        {
            // For protected routes, check if user is authenticated
            if (!context.User.Identity?.IsAuthenticated ?? true)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(new { error = "Unauthorized" });
                return;
            }
        }

        await _next(context);
    }
}

public static class ProxyAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseProxyAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ProxyAuthorizationMiddleware>();
    }
}
