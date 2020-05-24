using System;
using FilterLists.Domain.Entities;
using FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class SoftwareEntityTypeConfiguration : AuditableEntityTypeConfiguration<Software>
    {
        public override void Configure(EntityTypeBuilder<Software> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            base.Configure(builder);
            builder.ToTable("software");
            builder.Property(x => x.DownloadUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.HomeUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(126)")
                .IsRequired();
        }
    }
}