using RestaurantAPI.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Dish : AuditableBaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }

        // Navigation Properties
        public int CategoryId { get; set; }
        public DishCategory DishCategory { get; set; }

        public ICollection<DishIngredient> DishIngredients { get; set; }
        public ICollection<OrderDish> OrderDishes { get; set; }
    }
}
