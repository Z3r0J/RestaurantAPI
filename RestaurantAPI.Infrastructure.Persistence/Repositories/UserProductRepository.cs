using RestaurantAPI.Core.Application.Interfaces.Repository;
using RestaurantAPI.Core.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class UserProductRepository:GenericRepository<UserProduct>, IUserProductRepository
    {
        private readonly ApplicationContext _applicationContext;
        public UserProductRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<UserProduct>> GetIncludeAsync() {

            return await _applicationContext.Set<UserProduct>().Include(up => up.Product).ToListAsync();
        }
    }
}
