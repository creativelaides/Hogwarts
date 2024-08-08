using Hogwarts.Domain.Interfaces;
using Hogwarts.Infrastructure;
using Hogwarts.Infrastructure.Identities.Models;
using Hogwarts.Infrastructure.Reports;
using Microsoft.AspNetCore.Identity;

namespace Hogwarts.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services
        .AddIdentityCore<AppUser>(
            options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<HogwartsDbContext>();

        services.AddScoped(typeof(IReportServices<>), typeof(ReportService<>));

        return services;
    }
}