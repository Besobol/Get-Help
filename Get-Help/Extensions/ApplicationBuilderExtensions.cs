﻿using Get_Help.Infrastructure.Data.Models;
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
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Agent>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AgentRole>>();

            if (userManager != null && roleManager != null)
            {
                AgentRole role;
                Agent admin;

                if (await roleManager.RoleExistsAsync(adminRole) == false) 
                {
                    role = new AgentRole(adminRole);
                    await roleManager.CreateAsync(role);
                }
                else
                {
                    role = await roleManager.FindByNameAsync(adminRole);
                }

                admin = await userManager.FindByEmailAsync(adminEmail);

                if (admin == null)
                {
                    admin = new Agent() { Name = role.Name};
                    await userManager.SetEmailAsync(admin, adminEmail);

                    admin.Id = int.MaxValue;

                    await userManager.SetUserNameAsync(admin, adminEmail);

                    admin.Id = 0;

                    await userManager.CreateAsync(admin, adminPassword);
                }

                if (await userManager.IsInRoleAsync(admin, adminRole) == false)
                {
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }

        }
    }
}
