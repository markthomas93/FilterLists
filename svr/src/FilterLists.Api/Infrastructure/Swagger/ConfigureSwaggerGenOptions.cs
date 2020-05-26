using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FilterLists.Api.Infrastructure.Swagger
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
                options.SwaggerDoc(
                    description.GroupName,
                    new OpenApiInfo
                    {
                        Title = "FilterLists API",
                        Description =
                            "The independent, comprehensive directory of filter and host lists for advertisements, trackers, malware, and annoyances.",
                        Version = description.GroupName,
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
            options.IncludeXmlComments(xmlPath);
            options.OperationFilter<SwaggerDefaultValuesOperationFilter>();
            options.OperationFilter<OdataQueryParametersOperationFilter>();
        }
    }
}