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
    public class DefaultWaiterUser
    {
        public static async Task SeedAsync(UserManager<RestaurantUsers> userManager, RoleManager<IdentityRole> roleManager)
        {
            RestaurantUsers WaiterUser = new() {
                UserName = "DefaultWaiter",
                Name = "Waiter Jean",
                LastName = "Reyes",
                Email = "waiter@restaurantapi.com.do",
                Documents = "402-0000000-4",
                EmailConfirmed = true,
                PhoneNumber="+1 809 935 0913",
                PhoneNumberConfirmed = true
            };


            if (userManager.Users.All(u=>u.Id!=WaiterUser.Id))
            {
                var user = await userManager.FindByEmailAsync(WaiterUser.Email);

                if (user==null)
                {
                    await userManager.CreateAsync(WaiterUser,"P@ssw0rd");

                    await userManager.AddToRoleAsync(WaiterUser,Roles.WAITER.ToString());
                }
            }
            
                   }
    }
}
