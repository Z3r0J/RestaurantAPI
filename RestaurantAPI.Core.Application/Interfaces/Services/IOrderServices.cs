using RestaurantAPI.Core.Application.ViewModel.Order;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IOrderServices : IGenericServices<SaveOrderViewModel,OrderViewModel,Order>
    {
        Task<List<OrderViewModel>> GetAllViewModelWithInclude();
    }
}
