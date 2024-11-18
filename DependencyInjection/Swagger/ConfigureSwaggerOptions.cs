using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace DesafioFinal.WebApi.DependencyInjection.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {

        /*public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) 
        {
            _provider = provider;
        }*/

        public ConfigureSwaggerOptions() 
        {
        }

        /*public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions) 
            {
                options.SwaggerDoc(description.GroupName, CreateInfo(description));
            }
        }*/

        private static OpenApiInfo CreateInfo(ApiVersionDescription description) 
        {
            var dateVersion = File.GetCreationTime(Assembly.GetExecutingAssembly().Location);

            var deprecated = description.IsDeprecated ? "This api versaion has deprecated." : string.Empty;

            var openInfo = new OpenApiInfo 
            {
                Title = "Desafio Final",
                Description = "Desafio Final",
                Version = description.ApiVersion.ToString(),
                License = new OpenApiLicense { Name = $"Version generation data {dateVersion}"}
            };

            return openInfo;
        }

        public void Configure(SwaggerGenOptions options)
        {
        }
    }
}
