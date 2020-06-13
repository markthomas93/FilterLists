using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FilterLists.Infrastructure.Persistence
{
    public static class SeedExtensions
    {
        public static void HasDataJsonFile<TEntity>(this EntityTypeBuilder builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            var path = Path.Combine("../../../data", $"{typeof(TEntity).Name}.json");
            if (!File.Exists(path)) return;

            var entitiesJson = File.ReadAllText(path);
            var entities = JsonSerializer.Deserialize<IEnumerable<TEntity>>(entitiesJson, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            builder.HasData((IEnumerable<object>) entities);
        }

        public static IHost Migrate<TContext>(this IHost host) where TContext : DbContext
        {
            _ = host ?? throw new ArgumentNullException(nameof(host));

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetService<TContext>();
            context.Database.Migrate();
            return host;
        }
    }
}