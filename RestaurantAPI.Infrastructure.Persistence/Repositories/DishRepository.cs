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
    public class DishRepository : GenericRepository<Dish>,IDishRepository
    {
        private readonly ApplicationContext _applicationContext;

        public DishRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Dish>> GetAllExtensiveInclude() {

            return await _applicationContext.Set<Dish>()
                .Include(x => x.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .Include(x => x.DishCategory).ToListAsync();

        }
    }
}
