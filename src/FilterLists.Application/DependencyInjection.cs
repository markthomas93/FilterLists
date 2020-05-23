using Microsoft.Extensions.DependencyInjection;

namespace FilterLists.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}