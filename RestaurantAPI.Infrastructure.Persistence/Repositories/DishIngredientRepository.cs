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
    public class DishIngredientRepository : GenericRepository<DishIngredient>,IDishIngredientRepository
    {
        private readonly ApplicationContext _applicationContext;

        public DishIngredientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
