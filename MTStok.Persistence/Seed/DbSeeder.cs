using Microsoft.AspNetCore.Identity;
using MTStok.Domain.Entities;
using System.Threading.Tasks;

namespace MTStok.Persistence.Seed
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "SystemAdmin", "Manager", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminEmail = "admin@mtstok.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new AppUser
                {
                    UserName = "admin",
                    Email = adminEmail,
                    FullName = "Murat Tanrısever",
                    EmailConfirmed = true,
                    IsActive = true
                };

                await userManager.CreateAsync(admin, "Admin123!");
                await userManager.AddToRoleAsync(admin, "SystemAdmin");
            }

            var userEmail = "suad@mtstok.com";
            if (await userManager.FindByEmailAsync(userEmail) == null)
            {
                var suad = new AppUser
                {
                    UserName = "suad",
                    Email = userEmail,
                    FullName = "Suad",
                    EmailConfirmed = true,
                    IsActive = true
                };

                await userManager.CreateAsync(suad, "Suad123!");
                await userManager.AddToRoleAsync(suad, "User");
            }
        }
    }
}