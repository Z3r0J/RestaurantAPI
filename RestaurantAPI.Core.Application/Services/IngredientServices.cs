using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repository;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModel.Ingredient;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Services
{
    public class IngredientServices : GenericServices<SaveIngredientViewModel,IngredientViewModel,Ingredients>,IIngredientServices
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public IngredientServices(IIngredientRepository ingredientRepository,IMapper mapper):base(ingredientRepository,mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }
    }
}
