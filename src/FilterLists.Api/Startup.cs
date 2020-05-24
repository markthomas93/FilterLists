using FilterLists.Application;
using FilterLists.Infrastructure;
using GraphQL.Server.Ui.Playground;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
            services.AddGraphQL(SchemaBuilder.New().AddQueryType<FilterListQuery>());
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseGraphQL();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions {GraphQLEndPoint = PathString.Empty});
        }
    }
}