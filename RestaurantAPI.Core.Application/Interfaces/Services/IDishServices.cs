using RestaurantAPI.Core.Application.ViewModel.Dish;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IDishServices : IGenericServices<SaveDishViewModel,DishViewModel,Dish>
    {
        Task<List<DishViewModel>> GetAllViewModelWithInclude();
        Task<DishViewModel> GetByIdWithInclude(int id);
    }
}
