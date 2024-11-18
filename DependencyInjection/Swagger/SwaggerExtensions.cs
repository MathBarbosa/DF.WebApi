using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Net.NetworkInformation;

namespace DesafioFinal.WebApi.DependencyInjection.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection service) 
        {
            service.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            service.AddSwaggerGen( c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DF", Version = "v1" });
            });
                
            return service;
        }

        public static IApplicationBuilder UseSwaggerConfigurarion(this IApplicationBuilder app, string appName) 
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DF");
            });

            return app;
        }
    }
}
