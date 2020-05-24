using FilterLists.Api.GraphQL;
using FilterLists.Application;
using FilterLists.Infrastructure;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
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
            services.AddSingleton<ISchema, FilterListSchema>();
            services.AddGraphQL().AddGraphTypes(ServiceLifetime.Scoped);
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseGraphQL<FilterListSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}