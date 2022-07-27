using RestaurantAPI.Core.Application.ViewModel.DishIngredient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModel.Dish
{
    public class SaveDishViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(1.00,double.MaxValue,ErrorMessage="Prices will be greater than 0")]
        public double Price { get; set; }

        // Navigation Properties
        public int CategoryId { get; set; }

        public List<int> IngredientIds { get; set; }
    }
}
