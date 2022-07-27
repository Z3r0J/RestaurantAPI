using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repository;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModel.Dish;
using RestaurantAPI.Core.Application.ViewModel.Ingredient;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Services
{
    public class DishServices : GenericServices<SaveDishViewModel,DishViewModel,Dish>,IDishServices
    {
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;
        public DishServices(IDishRepository dishRepository, IMapper mapper) : base(dishRepository,mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        public async Task<List<DishViewModel>> GetAllViewModelWithInclude() {

           var response = await _dishRepository.GetAllExtensiveInclude();

            return _mapper.Map<List<DishViewModel>>(response);
        }
        public async Task<DishViewModel> GetByIdWithInclude(int id) {

           var response = await _dishRepository.GetAllExtensiveInclude();

            return _mapper.Map<DishViewModel>(response.FirstOrDefault(x=>x.Id==id));
        }

    }
}
