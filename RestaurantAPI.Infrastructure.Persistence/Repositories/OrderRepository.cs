using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repository;
using RestaurantAPI.Core.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class OrderRepository :GenericRepository<Order>,IOrderRepository
    {
        private readonly ApplicationContext _applicationContext;

        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Order>> GetExtensiveIncludeAsync() {

            return await _applicationContext.Set<Order>()
                .Include(x => x.Table)
                .ThenInclude(x => x.TableStatus)
                .Include(x => x.OrderDishes)
                .ThenInclude(x => x.Dish)
                .ThenInclude(x => x.DishCategory)
                .Include(x => x.OrderStatus).ToListAsync();
        
        }

    }
}
