using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;
using System.Security.Claims;

namespace Dotland.DotCapital.WebApi.Web.Transforms;

public static class ProxyTransformExtensions
{
    public static void AddJwtForwardingTransforms(this TransformBuilderContext context)
    {
        context.AddRequestTransform(async transformContext =>
        {
            var httpContext = transformContext.HttpContext;

            // Forward Authorization header if present
            if (httpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                transformContext.ProxyRequest.Headers.TryAddWithoutValidation("Authorization", authHeader.ToString());
            }

            // Add user context headers if authenticated
            if (httpContext.User.Identity?.IsAuthenticated == true)
            {
                var email = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(email))
                {
                    transformContext.ProxyRequest.Headers.TryAddWithoutValidation("X-User-Email", email);
                }
            }

            // Add X-Forwarded headers
            transformContext.ProxyRequest.Headers.TryAddWithoutValidation("X-Forwarded-Host", httpContext.Request.Host.ToString());
            transformContext.ProxyRequest.Headers.TryAddWithoutValidation("X-Forwarded-Proto", httpContext.Request.Scheme);

            await Task.CompletedTask;
        });
    }
}
