using System;
using FilterLists.Domain.Entities;
using FilterLists.Infrastructure.Persistence.EntityTypeConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class FilterListEntityTypeConfiguration : AuditableEntityTypeConfiguration<FilterList>
    {
        public override void Configure(EntityTypeBuilder<FilterList> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            base.Configure(builder);
            builder.ToTable("filterlists");
            builder.Property(x => x.ChatUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.Description)
                .HasColumnType("TEXT");
            builder.Property(x => x.DescriptionSourceUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.DonateUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.EmailAddress)
                .HasColumnType("VARCHAR(126)")
                .HasDefaultValueSql("NULL");
            builder.Property(x => x.ForumUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.HomeUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.IssuesUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.LicenseId)
                .HasDefaultValue(5);
            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(126)")
                .IsRequired();
            builder.Property(x => x.PolicyUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.PublishedDate)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("NULL");
            builder.Property(x => x.SubmissionUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.UpdatedDate)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("NULL");
            builder.Property(x => x.ViewUrl)
                .HasColumnType("TEXT");
            builder.Property(x => x.ViewUrlMirror1)
                .HasColumnType("TEXT");
            builder.Property(x => x.ViewUrlMirror2)
                .HasColumnType("TEXT");
        }
    }
}