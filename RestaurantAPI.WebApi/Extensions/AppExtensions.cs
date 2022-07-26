﻿using Microsoft.AspNetCore.Builder;

namespace RestaurantAPI.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder application) { 
        
            application.UseSwagger();
            application.UseSwaggerUI(options => {

                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API");
                
            });
        
        }
    }
}
