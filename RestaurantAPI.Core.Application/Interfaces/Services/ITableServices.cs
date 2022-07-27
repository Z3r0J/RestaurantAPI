using RestaurantAPI.Core.Application.ViewModel.Order;
using RestaurantAPI.Core.Application.ViewModel.Table;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface ITableServices :IGenericServices<SaveTableViewModel,TableViewModel,Table>
    {
        Task<List<TableViewModel>> GetAllWithInclude();
        Task<TableViewModel> GetByIdWithInclude(int id);
        Task<List<OrderViewModel>> GetOrderByTable(int id);
    }
}
