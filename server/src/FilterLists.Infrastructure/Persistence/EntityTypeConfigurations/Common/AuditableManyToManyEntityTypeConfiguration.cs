using System;
using FilterLists.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common
{
    public class
        AuditableManyToManyEntityTypeConfiguration<TAuditableManyToManyEntity> : IEntityTypeConfiguration<
            TAuditableManyToManyEntity> where TAuditableManyToManyEntity : AuditableManyToManyEntity
    {
        public virtual void Configure(EntityTypeBuilder<TAuditableManyToManyEntity> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.Property(x => x.CreatedDateUtc)
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasDefaultValueSql("current_timestamp()");
            builder.HasDataJsonFile<TAuditableManyToManyEntity>();
        }
    }
}