using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Domain.Settings;
using RestaurantAPI.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace RestaurantAPI.Infrastructure.Shared
{
    public static class ServicesRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {

            service.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            service.AddTransient<IEmailServices, EmailServices>();
        }
    }
}
