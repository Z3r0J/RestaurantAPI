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
    public class DefaultSuperAdminUser
    {
        public static async Task SeedAsync(UserManager<RestaurantUsers> userManager, RoleManager<IdentityRole> roleManager)
        {
            RestaurantUsers SuperAdminUser = new() {
                UserName = "SuperAdminUser",
                Name = "Waiter Jean",
                LastName = "Reyes",
                Email = "superadmin@restaurantapi.com.do",
                Documents = "402-0000000-4",
                EmailConfirmed = true,
                PhoneNumber="+1 809 935 0913",
                PhoneNumberConfirmed = true
            };


            if (userManager.Users.All(u=>u.Id!=SuperAdminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(SuperAdminUser.Email);

                if (user==null)
                {
                    await userManager.CreateAsync(SuperAdminUser,"P@ssw0rd");

                    await userManager.AddToRoleAsync(SuperAdminUser,Roles.SUPERADMINISTRATOR.ToString());
                    await userManager.AddToRoleAsync(SuperAdminUser,Roles.ADMINISTRATOR.ToString());
                    await userManager.AddToRoleAsync(SuperAdminUser,Roles.WAITER.ToString());
                }
            }
            
                   }
    }
}
