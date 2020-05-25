using FilterLists.Api.Odata;
using FilterLists.Api.Swagger;
using FilterLists.Application;
using FilterLists.Infrastructure;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
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
            services.AddOData();
            services.AddControllers(o => o.SetOdataOutputFormatters())
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerGenCustom();
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
                e.ConfigureOdata();
            });
            app.UseSwaggerCustom();
        }
    }
}