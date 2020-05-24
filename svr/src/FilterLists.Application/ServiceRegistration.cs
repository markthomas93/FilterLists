using Microsoft.Extensions.DependencyInjection;

namespace FilterLists.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}