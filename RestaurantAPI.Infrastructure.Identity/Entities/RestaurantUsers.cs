using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Identity.Entities
{
    public class RestaurantUsers : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Documents { get; set; }
    }
}
