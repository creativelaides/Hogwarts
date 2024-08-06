using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Hogwarts.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
        );
        return services;
    }
}