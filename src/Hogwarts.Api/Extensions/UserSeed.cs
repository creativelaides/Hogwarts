using Hogwarts.Domain.Entities;
using Hogwarts.Infrastructure;
using Hogwarts.Infrastructure.Identities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Api.Extensions;

public static class UserSeed
{
    public static async Task SeedDataAuthentication(
        this IApplicationBuilder app
    ){
        using  var scope = app.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider;
        var loggerFactory = service.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = service.GetRequiredService<HogwartsDbContext>();
            await context.Database.MigrateAsync();

            var userManager = service.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any())
            {
                var userAdmin = new AppUser
                {
                    FirstName = "Jose",
                    LastName = "Velaides",
                    Career = "Backend Developer",
                    UserName = "creativelaides",
                    Email = "creativelaides@gmail.com"
                };

                await userManager.CreateAsync(userAdmin, "P@ssw0rd123");
                await userManager.AddToRoleAsync(userAdmin, CustomRoles.ADMIN);

                var userClient = new AppUser
                {
                    FirstName = "Stephania",
                    LastName = "Jaimes",
                    Career = "Piscologa",
                    UserName = "StephaJaimes",
                    Email = "stephajaimes@gmail.com"
                };

                await userManager.CreateAsync(userClient, "P@ssw0rd123");
                await userManager.AddToRoleAsync(userClient, CustomRoles.CLIENT);
            }
        }
        catch (Exception e)
        {
            var logger = loggerFactory.CreateLogger<HogwartsDbContext>();
            logger.LogError(e, "An error occurred while seeding the database.");
        } 
    }
}