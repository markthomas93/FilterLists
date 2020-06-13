using System;
using FilterLists.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common
{
    public class AuditableEntityTypeConfiguration<TAuditableEntity> : IEntityTypeConfiguration<TAuditableEntity>
        where TAuditableEntity : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<TAuditableEntity> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.Property(x => x.Id)
                .UseMySqlIdentityColumn()
                .HasColumnType("SMALLINT");
            builder.Property(x => x.CreatedDateUtc)
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasDefaultValueSql("current_timestamp()");
            builder.Property(x => x.ModifiedDateUtc)
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired()
                .HasDefaultValueSql("current_timestamp() ON UPDATE current_timestamp()");
            builder.HasDataJsonFile<TAuditableEntity>();
        }
    }
}