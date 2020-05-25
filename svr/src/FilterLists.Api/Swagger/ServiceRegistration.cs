using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
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

        public static void UseSwaggerCustom(this IApplicationBuilder app)
        {
            app.UseSwagger(o => o.PreSerializeFilters.Add((openApiDocument, _) =>
                openApiDocument.Servers = new List<OpenApiServer> {new OpenApiServer {Url = "/api"}}));
            app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "FilterLists API V1"));
        }
    }
}