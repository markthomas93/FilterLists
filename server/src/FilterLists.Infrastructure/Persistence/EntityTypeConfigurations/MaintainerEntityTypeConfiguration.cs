using System;
using FilterLists.Domain.Entities;
using FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class MaintainerEntityTypeConfiguration : AuditableEntityTypeConfiguration<Maintainer>
    {
        public override void Configure(EntityTypeBuilder<Maintainer> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            base.Configure(builder);
            builder.ToTable("maintainers");
            builder.Property(x => x.EmailAddress)
                .HasColumnType("VARCHAR(126)")
                .HasDefaultValueSql("NULL");
            builder.Property(x => x.HomeUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(126)")
                .IsRequired();
            builder.Property(x => x.TwitterHandle)
                .HasColumnType("VARCHAR(126)")
                .HasDefaultValueSql("NULL");
        }
    }
}