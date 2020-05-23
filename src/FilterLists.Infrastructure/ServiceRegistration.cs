using System;
using FilterLists.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace FilterLists.Infrastructure
{
    public static class ServiceRegistration
    {
        private static readonly ServerVersion ServerVersion =
            new ServerVersion(new Version(10, 5, 3), ServerType.MariaDb);

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<FilterListsDbContext>(o =>
                o.UseMySql(config.GetConnectionString("FilterListsConnection"),
                    m => m.MigrationsAssembly("FilterLists.Infrastructure.Migrations").ServerVersion(ServerVersion)));
            return services;
        }
    }
}