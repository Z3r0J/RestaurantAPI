using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModel.Ingredient
{
    public class SaveIngredientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The name is required")]
        public string Name { get; set; }
    }
}
