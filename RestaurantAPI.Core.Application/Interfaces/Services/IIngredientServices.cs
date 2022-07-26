using RestaurantAPI.Core.Application.ViewModel.Ingredient;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IIngredientServices :IGenericServices<SaveIngredientViewModel,IngredientViewModel,Ingredients>
    {
    }
}
