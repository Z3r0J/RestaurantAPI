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
    public class PaymentRepository:GenericRepository<Payment>, IPaymentRepository
    {
        private readonly ApplicationContext _applicationContext;
        public PaymentRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Payment>> GetIncludeAsync() {

            return await _applicationContext.Set<Payment>().Include(up => up.TypePayment).ToListAsync();

        }
    }
}
