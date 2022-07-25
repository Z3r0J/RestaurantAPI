using RestaurantAPI.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class DishCategory : AuditableBaseEntity
    {
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Dish> Dishes { get; set; }
    }
}
