using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection service) {

            service.AddSwaggerGen(options => {

                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();

                xmlFiles.ForEach(xmlFiles => options.IncludeXmlComments(xmlFiles));

                options.SwaggerDoc("v1", new OpenApiInfo { 
                
                    Version="v1",
                    Title = "Restaurant API",
                    Description = "This API is created for services using in a Restaurant.",
                    Contact = new OpenApiContact { 
                    Name = "Jean Carlos Reyes",
                    Email = "jeanrey.ese@gmail.com",
                    Url = new Uri("https://github.com/z3r0j")
                    }

                });

                options.DescribeAllParametersInCamelCase();
            });

        }

        public static void AddApiVersioningExtension(this IServiceCollection services) {

            services.AddApiVersioning(config => {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            
            });

        }
    }
}
