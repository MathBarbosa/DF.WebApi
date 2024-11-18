using DesafioFinal.Application.DependencyInjection.Extensions;
using DesafioFinal.Domain.Interfaces.Repositories;
using DesafioFinal.Infra.Repositories.Client;
using DesafioFinal.WebApi.DependencyInjection.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;
using System.Text.Json.Serialization;

namespace DF.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault((Assembly assembly) => assembly.GetName().Name.Contains("Application"));

            services.AddControllers()
                .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

            services.AddSingleton<IClientRepository, ClientRepository>();

            services
                .AddUseCases()
                .AddLogging()
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies))
                .AddSwaggerConfig(); 
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) application.UseDeveloperExceptionPage();

            application
                .UseRouting()
                .UseHttpsRedirection()
                .UseSwaggerConfigurarion("DF")
                .UseEndpoints(endpoint => 
                {
                    endpoint.MapControllers();
                });
        }
    }
}
