using RestaurantAPI.Core.Application.ViewModel.DishIngredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModel.Dish
{
    public class SaveDishViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        // Navigation Properties
        public int CategoryId { get; set; }

        public List<int> IngredientIds { get; set; }

        [JsonIgnore]
        public List<SaveDishIngredientViewModel> DishIngredients { get; set; }
    }
}
