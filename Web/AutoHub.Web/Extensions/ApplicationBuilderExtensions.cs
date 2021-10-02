﻿namespace AutoHub.Web.Extensions
{
    using AutoHub.Common;
    using AutoHub.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddInitialAdmin(this IApplicationBuilder app) 
        {

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (!userManager.Users.AnyAsync(x => x.Email == "ppenchev1@gmail.com").GetAwaiter().GetResult())
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "ppenchev1@gmail.com",
                    EmailConfirmed = true,

                };

                var result = userManager.CreateAsync(user, "Admin11109988").GetAwaiter().GetResult();

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                }
            }

            return app;
        }
    }
}
