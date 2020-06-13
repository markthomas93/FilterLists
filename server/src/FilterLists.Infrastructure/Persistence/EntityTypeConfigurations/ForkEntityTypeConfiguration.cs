using System;
using FilterLists.Domain.Entities;
using FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class ForkEntityTypeConfiguration : AuditableManyToManyEntityTypeConfiguration<Fork>
    {
        public override void Configure(EntityTypeBuilder<Fork> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            base.Configure(builder);
            builder.ToTable("forks");
            builder.HasKey(x => new {x.ForkFilterListId, x.UpstreamFilterListId});
            builder.HasOne(x => x.ForkFilterList)
                .WithMany(x => x.ForkFilterLists)
                .HasForeignKey(x => x.ForkFilterListId);
            builder.HasOne(x => x.UpstreamFilterList)
                .WithMany(x => x.UpstreamForkFilterLists)
                .HasForeignKey(x => x.UpstreamFilterListId);
        }
    }
}