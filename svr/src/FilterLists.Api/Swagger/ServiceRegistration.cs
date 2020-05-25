using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FilterLists.Api.Swagger
{
    public static class ServiceRegistration
    {
        public static void AddSwaggerGenCustom(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
            services.AddSwaggerGen();
        }

        public static void UseSwaggerCustom(this IApplicationBuilder app,
            IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            app.UseSwagger(o => o.PreSerializeFilters.Add((openApiDocument, _) =>
                openApiDocument.Servers = new List<OpenApiServer> {new OpenApiServer {Url = "/api"}}));
            app.UseSwaggerUI(o =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    o.SwaggerEndpoint($"{description.GroupName}/swagger.json",
                        $"FilterLists API {description.GroupName}");
            });
        }
    }
}