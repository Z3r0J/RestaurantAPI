using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Infrastructure.Identity.Contexts;
using RestaurantAPI.Infrastructure.Identity.Entities;
using RestaurantAPI.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using RestaurantAPI.Core.Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace RestaurantAPI.Infrastructure.Identity
{
    public static class ServicesRegistration
    {

        public static void AddIdentityInfrastructure(this IServiceCollection service, IConfiguration configuration) {

            #region Contexts

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<IdentityContext>(options => options.UseInMemoryDatabase("IdentityMemory"));
            }
            else
            {
                service.AddDbContext<IdentityContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"), 
                m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));
            }
            #endregion

            #region Identity
            service.AddIdentity<RestaurantUsers, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            service.ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/User/Login";
                    options.AccessDeniedPath = "/User/AccessDenied";
                });

            service.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            service.AddAuthentication(options => {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=>
            {

                options.RequireHttpsMetadata = false;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                };

                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c => {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },

                   OnChallenge = c => {

                       return c;
                   
                   }
                };

            });


            #endregion

            #region Services

            service.AddTransient<IAccountServices, AccountServices>();

            #endregion

        }

    }
}
