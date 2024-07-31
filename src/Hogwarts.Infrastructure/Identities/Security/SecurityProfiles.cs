using System.Globalization;
using Hogwarts.Infrastructure.Identities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Infrastructure.Identities.Security;

internal static class SecurityProfiles
{
    internal static void UploadSecurityProfiles(ModelBuilder modelBuilder)
    {
        var adminId = Guid.NewGuid().ToString();
        var clientId = Guid.NewGuid().ToString();
        
        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Id = adminId,
                    Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(CustomRoles.ADMIN.ToLower()),
                    NormalizedName = CustomRoles.ADMIN
                },

                new IdentityRole
                {
                    Id = clientId,
                    Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(CustomRoles.CLIENT.ToLower()),
                    NormalizedName = CustomRoles.CLIENT
                }
            );
        
        modelBuilder.Entity<IdentityRoleClaim<string>>()
            .HasData(
                new IdentityRoleClaim<string>
                {
                    Id = 1,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.COURSE_CREATE,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 2,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.COURSE_READ,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 3,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.COURSE_UPDATE,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 4,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.COURSE_DELETE,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 5,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.PROFESSOR_READ,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 6,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.PROFESSOR_CREATE,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 7,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.PROFESSOR_UPDATE,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 8,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.PROFESSOR_DELETE,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 9,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.STUDENT_READ,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 10,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.STUDENT_CREATE,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 11,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.STUDENT_UPDATE,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 12,
                    RoleId = adminId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.STUDENT_DELETE,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 13,
                    RoleId = clientId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.COURSE_READ,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 14,
                    RoleId = clientId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.PROFESSOR_READ,
                },

                new IdentityRoleClaim<string>
                {
                    Id = 15,
                    RoleId = clientId,
                    ClaimType = CustomClaims.POLICIES,
                    ClaimValue = CustomPolicies.STUDENT_READ,
                }
            );
    }
}