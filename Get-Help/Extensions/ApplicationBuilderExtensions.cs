using Get_Help.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Get_Help.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            string adminRole = "Admin";
            string adminEmail = "admin@gethelp.com";
            string adminPassword = "AdminForever";

            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            if (userManager != null && roleManager != null)
            {
                ApplicationRole role;
                ApplicationUser admin;

                if (await roleManager.RoleExistsAsync(adminRole) == false) 
                {
                    role = new ApplicationRole(adminRole);
                    await roleManager.CreateAsync(role);
                }
                else
                {
                    role = await roleManager.FindByNameAsync(adminRole);
                }

                admin = await userManager.FindByEmailAsync(adminEmail);

                if (admin == null)
                {
                    admin = new ApplicationUser();
                    await userManager.SetEmailAsync(admin, adminEmail);

                    admin.Id = int.MaxValue;

                    await userManager.SetUserNameAsync(admin, adminEmail);

                    admin.Id = 0;

                    var result = await userManager.CreateAsync(admin, adminPassword);
                }

                if (await userManager.IsInRoleAsync(admin, adminRole) == false)
                {
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }

        }
        public static async Task CreateClientRoleAsync(this IApplicationBuilder app)
        {
            string userRole = "Client";

            using var scope = app.ApplicationServices.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            if (roleManager != null)
            {
                ApplicationRole role;

                if (await roleManager.RoleExistsAsync(userRole) == false)
                {
                    role = new ApplicationRole(userRole);
                    await roleManager.CreateAsync(role);
                }
            }
        }
        public static async Task CreateAgentRoleAsync(this IApplicationBuilder app)
        {
            string userRole = "Agent";

            using var scope = app.ApplicationServices.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            if (roleManager != null)
            {
                ApplicationRole role;

                if (await roleManager.RoleExistsAsync(userRole) == false)
                {
                    role = new ApplicationRole(userRole);
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
