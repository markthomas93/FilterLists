using System;
using FilterLists.Domain.Entities;
using FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class
        FilterListMaintainerEntityTypeConfiguration : AuditableManyToManyEntityTypeConfiguration<FilterListMaintainer>
    {
        public override void Configure(EntityTypeBuilder<FilterListMaintainer> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            base.Configure(builder);
            builder.ToTable("filterlists_maintainers");
            builder.HasKey(x => new {x.FilterListId, x.MaintainerId});
            builder.HasOne(x => x.FilterList)
                .WithMany(x => x.FilterListMaintainers)
                .HasForeignKey(x => x.FilterListId);
            builder.HasOne(x => x.Maintainer)
                .WithMany(x => x.FilterListMaintainers)
                .HasForeignKey(x => x.MaintainerId);
        }
    }
}