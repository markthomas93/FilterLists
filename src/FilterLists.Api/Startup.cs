using FilterLists.Api.GraphQL;
using FilterLists.Application;
using FilterLists.Infrastructure;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
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
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService!));
            services.AddScoped<ISchema, FilterListSchema>();
            services.AddGraphQL().AddGraphTypes(ServiceLifetime.Scoped);
            services.Configure<KestrelServerOptions>(o =>
            {
                //TODO: limitation of GraphQL using Newtonsoft.JSON
                o.AllowSynchronousIO = true;
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}