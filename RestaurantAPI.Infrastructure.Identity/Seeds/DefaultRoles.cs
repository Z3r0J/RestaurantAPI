using RestaurantAPI.Core.Application.Enums;
using RestaurantAPI.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<RestaurantUsers> userManager,RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new(Roles.ADMINISTRATOR.ToString()));            
            await roleManager.CreateAsync(new(Roles.WAITER.ToString()));


        }
    }
}
