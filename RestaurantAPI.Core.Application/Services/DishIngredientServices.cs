using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repository;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModel.DishIngredient;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Services
{
    public class DishIngredientServices : GenericServices<SaveDishIngredientViewModel,DishIngredientViewModel,DishIngredient>,IDishIngredientServices
    {
        private readonly IDishIngredientRepository _dishIngredientRepository;
        private readonly IMapper _mapper;
        public DishIngredientServices(IDishIngredientRepository dishIngredientRepository, IMapper mapper):base(dishIngredientRepository, mapper)
        {
            _dishIngredientRepository = dishIngredientRepository;
            _mapper = mapper;
        }
    }
}
