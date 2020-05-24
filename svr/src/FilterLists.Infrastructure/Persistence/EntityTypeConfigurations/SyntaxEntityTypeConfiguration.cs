using System;
using FilterLists.Domain.Entities;
using FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class SyntaxEntityTypeConfiguration : AuditableEntityTypeConfiguration<Syntax>
    {
        public override void Configure(EntityTypeBuilder<Syntax> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            base.Configure(builder);
            builder.ToTable("syntaxes");
            builder.Property(x => x.DefinitionUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(126)")
                .IsRequired();
        }
    }
}