using System;
using System.Collections.Generic;
using System.Linq;
using FilterLists.Application;
using FilterLists.Infrastructure;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Microsoft.OpenApi.Models;

namespace FilterLists.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
            services.AddApplication();
            services.Configure<ForwardedHeadersOptions>(o =>
                o.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto);
            services.AddOData();
            services.AddControllers(o =>
            {
                var oDataOutputFormatters = o.OutputFormatters.OfType<ODataOutputFormatter>()
                    .Where(f => f.SupportedMediaTypes.Count == 0);
                var odataMediaTypeHeaderValue = new MediaTypeHeaderValue("application/odata");
                foreach (var oDataOutputFormatter in oDataOutputFormatters)
                    oDataOutputFormatter.SupportedMediaTypes.Add(odataMediaTypeHeaderValue);
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
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
                        Name = "MIT",
                        Url = new Uri("https://github.com/collinbarrett/FilterLists/blob/master/LICENSE")
                    }
                });
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseRouting();
            app.UseEndpoints(e =>
            {
                e.MapControllers();
                e.MaxTop(10).Expand().Select().Filter().OrderBy().Count().SkipToken();
                e.MapODataRoute("odata", default, GetEdmModel());
            });
            app.UseSwagger(o =>
            {
                o.PreSerializeFilters.Add((openApiDocument, _) =>
                    openApiDocument.Servers = new List<OpenApiServer> {new OpenApiServer {Url = "/api"}});
            });
            app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "FilterLists API V1"));
        }

        private static IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<WeatherForecast>("WeatherForecast");
            return odataBuilder.GetEdmModel();
        }
    }
}