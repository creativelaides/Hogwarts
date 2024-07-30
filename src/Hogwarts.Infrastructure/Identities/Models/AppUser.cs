
using Microsoft.AspNetCore.Identity;

namespace Hogwarts.Infrastructure.Identities.Models;

public class AppUser: IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Career { get; set; }

    public AppUser()
    {     
    }
}



