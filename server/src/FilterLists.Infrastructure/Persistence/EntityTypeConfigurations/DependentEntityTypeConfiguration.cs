using System;
using FilterLists.Domain.Entities;
using FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class DependentEntityTypeConfiguration : AuditableManyToManyEntityTypeConfiguration<Dependent>
    {
        public override void Configure(EntityTypeBuilder<Dependent> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            base.Configure(builder);
            builder.ToTable("dependents");
            builder.HasKey(x => new {x.DependentFilterListId, x.DependencyFilterListId});
            builder.HasOne(x => x.DependentFilterList)
                .WithMany(x => x.DependentFilterLists)
                .HasForeignKey(x => x.DependentFilterListId);
            builder.HasOne(x => x.DependencyFilterList)
                .WithMany(x => x.DependencyFilterLists)
                .HasForeignKey(x => x.DependencyFilterListId);
        }
    }
}