using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModel.DishIngredient
{
    public class SaveDishIngredientViewModel
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int DishId { get; set; }
    }
}
