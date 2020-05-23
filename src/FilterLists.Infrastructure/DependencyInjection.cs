using Microsoft.Extensions.DependencyInjection;

namespace FilterLists.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}