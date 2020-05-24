using FilterLists.Application;
using FilterLists.Infrastructure;
using GraphQL.Server.Ui.Playground;
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
            services.AddApplication();
            services.AddInfrastructure(Configuration);
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}