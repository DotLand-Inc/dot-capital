using Dotland.DotCapital.WebApi.Application.Common.Interfaces;
using Dotland.DotCapital.WebApi.Infrastructure.Data;
using Dotland.DotCapital.WebApi.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Yarp.ReverseProxy.Transforms;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddWebServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddScoped<IUser, CurrentUser>();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddHealthChecks()
            .AddDbContextCheck<SystemDbContext>();

        builder.Services.AddExceptionHandler<CustomExceptionHandler>();
        builder.Services.AddHttpContextAccessor();
        // YARP Reverse Proxy
        builder.Services.AddReverseProxy()
            .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
            .AddTransforms(transformBuilderContext =>
            {
                transformBuilderContext.AddRequestTransform(context =>
                {
                   Console.WriteLine(context.HttpContext.Request.Headers["Authorization"]);

                    return ValueTask.CompletedTask;
                });
            });
            // .AddTransforms(builderContext =>
            // {
            //     builderContext.AddJwtForwardingTransforms();
            // });

        builder.Services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddEndpointsApiExplorer();
    }
}
