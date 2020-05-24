using System;
using FilterLists.Domain.Entities;
using FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class MergeEntityTypeConfiguration : AuditableManyToManyEntityTypeConfiguration<Merge>
    {
        public override void Configure(EntityTypeBuilder<Merge> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            base.Configure(builder);
            builder.ToTable("merges");
            builder.HasKey(x => new {x.MergeFilterListId, x.UpstreamFilterListId});
            builder.HasOne(x => x.MergeFilterList)
                .WithMany(x => x.MergeFilterLists)
                .HasForeignKey(x => x.MergeFilterListId);
            builder.HasOne(x => x.UpstreamFilterList)
                .WithMany(x => x.UpstreamMergeFilterLists)
                .HasForeignKey(x => x.UpstreamFilterListId);
        }
    }
}