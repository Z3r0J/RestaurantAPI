using RestaurantAPI.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class DishIngredient : AuditableBaseEntity 
    {
        public int IngredientId { get; set; }
        public Ingredients Ingredient { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
