using FilterLists.Application;
using FilterLists.Infrastructure;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;

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
            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.Configure<ForwardedHeadersOptions>(o =>
                o.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto);
            services.AddApiVersioning();
            services.AddOData().EnableApiVersioning();
            services.AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");
            services.AddOpenApiDocument(s => s.PostProcess = d => { d.Info.Title = "FilterLists API"; });
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
                e.Select().Filter().OrderBy().Count().MaxTop(10);
                e.MapODataRoute("odata", "odata", GetEdmModel());
            });
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }

        private static IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<WeatherForecast>("WeatherForecast");
            return odataBuilder.GetEdmModel();
        }
    }
}