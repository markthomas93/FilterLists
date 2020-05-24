using System;
using FilterLists.Domain.Entities;
using FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class SoftwareSyntaxEntityTypeConfiguration : AuditableManyToManyEntityTypeConfiguration<SoftwareSyntax>
    {
        public override void Configure(EntityTypeBuilder<SoftwareSyntax> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            base.Configure(builder);
            builder.ToTable("software_syntaxes");
            builder.HasKey(x => new {x.SyntaxId, x.SoftwareId});
            builder.HasOne(x => x.Software)
                .WithMany(x => x.SoftwareSyntaxes)
                .HasForeignKey(x => x.SoftwareId);
            builder.HasOne(x => x.Syntax)
                .WithMany(x => x.SoftwareSyntaxes)
                .HasForeignKey(x => x.SyntaxId);
        }
    }
}