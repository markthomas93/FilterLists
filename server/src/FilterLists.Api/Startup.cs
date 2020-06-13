using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FilterLists.Api.Controllers.V2;
using FilterLists.Api.Infrastructure.Swagger;
using FilterLists.Application;
using FilterLists.Infrastructure;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OData;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FilterLists.Api
{
    using static AllowedQueryOptions;
    using static CompatibilityVersion;
    using static ODataUrlKeyDelimiter;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static string XmlCommentsFilePath
        {
            get
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                return Path.Combine(AppContext.BaseDirectory, xmlFile);
            }
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
            services.AddApplication();
            services.AddControllers(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(Latest);
            services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddOData().EnableApiVersioning();
            services.AddODataApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;

                    // configure query options (which cannot otherwise be configured by OData conventions)
                    options.QueryOptions.Controller<PeopleController>()
                        .Action(c => c.Get(default))
                        .Allow(Skip | Count)
                        .AllowTop(100)
                        .AllowOrderBy("firstName", "lastName");

                    options.QueryOptions.Controller<Controllers.V3.PeopleController>()
                        .Action(c => c.Get(default))
                        .Allow(Skip | Count)
                        .AllowTop(100)
                        .AllowOrderBy("firstName", "lastName");
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();

                    // integrate xml comments
                    options.IncludeXmlComments(XmlCommentsFilePath);
                });
        }

        public static void Configure(IApplicationBuilder app, VersionedODataModelBuilder modelBuilder,
            IApiVersionDescriptionProvider provider)
        {
            app.UseMvc(
                routeBuilder =>
                {
                    // BUG: https://github.com/OData/WebApi/issues/1837
                    // routeBuilder.SetDefaultODataOptions( new ODataOptions() { UrlKeyDelimiter = Parentheses } );
                    routeBuilder.ServiceProvider.GetRequiredService<ODataOptions>().UrlKeyDelimiter = Parentheses;
                    routeBuilder.Count();
                    routeBuilder.MapVersionedODataRoutes("odata", string.Empty, modelBuilder.GetEdmModels());
                });
            app.UseSwagger(o => o.PreSerializeFilters.Add((openApiDocument, _) =>
                openApiDocument.Servers = new List<OpenApiServer> {new OpenApiServer {Url = "/api"}}));
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                        options.SwaggerEndpoint($"{description.GroupName}/swagger.json",
                            $"FilterLists API {description.GroupName}");
                });
        }
    }
}