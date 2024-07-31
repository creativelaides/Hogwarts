using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Hogwarts.Application;

public static class DependencyInjectionApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );
        return services;
    }
}