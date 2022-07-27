using RestaurantAPI.Core.Application.ViewModel.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModel.Dish
{
    public class DishViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public DishCategoryViewModel DishCategory { get; set; }
        public List<IngredientViewModel> Ingredient { get; set; }

    }
}
