using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
namespace GuestHibajelentesEvvegi;

public class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Define the roles
        string[] roleNames = { "admin", "sori alkalmazott", "szerelő" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                // Create the roles if they do not exist
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}

