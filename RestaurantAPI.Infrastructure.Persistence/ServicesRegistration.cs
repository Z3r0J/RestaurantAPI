using RestaurantAPI.Core.Application.Interfaces.Repository;
using RestaurantAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantAPI.Infrastructure.Persistence.Repositories;

namespace RestaurantAPI.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {

        public static void AddPersistenceInfrastructure(this IServiceCollection service, IConfiguration configuration) {

            #region Contexts

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("RestaurantAPIMemory"));
            }
            else
            {
                service.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("RestaurantAPIConnection"), 
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #endregion

            #region Repository

            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IIngredientRepository, IngredientRepository>();
            #endregion
        }

    }
}
