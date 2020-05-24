using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.Seed
{
    public static class SeedExtension
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
    }
}