using System.Reflection;
using Cortex.Mediator.DependencyInjection;
using Dotland.DotCapital.WebApi.Application.Customers;
using Microsoft.Extensions.Hosting;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<CustomerMapper>();

        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Services.AddCortexMediator(
            builder.Configuration,
            new[] { typeof(DependencyInjection) },
            options => options.AddDefaultBehaviors());
    }
}
