using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

#pragma warning disable 1591

namespace FilterLists.Api.Swagger
{
    public static class ServiceRegistration
    {
        public static void AddSwaggerGenCustom(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FilterLists API",
                    Description =
                        "The independent, comprehensive directory of filter and host lists for advertisements, trackers, malware, and annoyances.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "FilterLists",
                        Url = new Uri("https://github.com/collinbarrett/FilterLists")
                    },
                    License = new OpenApiLicense
                    {
                        Name = $"Released under MIT License. ©{DateTime.Now.Year} Collin M. Barrett",
                        Url = new Uri("https://github.com/collinbarrett/FilterLists/blob/master/LICENSE")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerCustom(this IApplicationBuilder app)
        {
            app.UseSwagger(o => o.PreSerializeFilters.Add((openApiDocument, _) =>
                openApiDocument.Servers = new List<OpenApiServer> {new OpenApiServer {Url = "/api"}}));
            app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "FilterLists API V1"));
        }
    }
}