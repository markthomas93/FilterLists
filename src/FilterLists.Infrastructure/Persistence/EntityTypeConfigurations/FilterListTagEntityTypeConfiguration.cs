using System;
using FilterLists.Domain.Entities;
using FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class FilterListTagEntityTypeConfiguration : AuditableManyToManyEntityTypeConfiguration<FilterListTag>
    {
        public override void Configure(EntityTypeBuilder<FilterListTag> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            base.Configure(builder);
            builder.ToTable("filterlists_tags");
            builder.HasKey(x => new {x.FilterListId, x.TagId});
            builder.HasOne(x => x.FilterList)
                .WithMany(x => x.FilterListTags)
                .HasForeignKey(x => x.FilterListId);
            builder.HasOne(x => x.Tag)
                .WithMany(x => x.FilterListTags)
                .HasForeignKey(x => x.TagId);
        }
    }
}