using FilterLists.Api.Infrastructure.Odata;
using FilterLists.Api.Infrastructure.Swagger;
using FilterLists.Application;
using FilterLists.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
                o.Conventions.Add(new VersionByNamespaceConvention());
            });
            services.AddOdataCustom();
            services.AddControllers(o => o.SetOdataOutputFormatters())
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerGenCustom();
        }

        public static void Configure(IApplicationBuilder app,
            IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseRouting();
            app.UseEndpoints(e =>
            {
                e.MapControllers();
                e.ConfigureOdata();
            });
            app.UseSwaggerCustom(apiVersionDescriptionProvider);
        }
    }
}