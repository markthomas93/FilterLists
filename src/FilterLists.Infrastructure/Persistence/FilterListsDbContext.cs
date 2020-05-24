using FilterLists.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilterLists.Infrastructure.Persistence
{
    public class FilterListsDbContext : DbContext
    {
        public FilterListsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dependent> Dependents { get; set; } = null!;
        public DbSet<FilterList> FilterLists { get; set; } = null!;
        public DbSet<FilterListLanguage> FilterListLanguages { get; set; } = null!;
        public DbSet<FilterListMaintainer> FilterListMaintainers { get; set; } = null!;
        public DbSet<FilterListTag> FilterListTags { get; set; } = null!;
        public DbSet<Fork> Forks { get; set; } = null!;
        public DbSet<Language> Languages { get; set; } = null!;
        public DbSet<License> Licenses { get; set; } = null!;
        public DbSet<Maintainer> Maintainers { get; set; } = null!;
        public DbSet<Merge> Merges { get; set; } = null!;
        public DbSet<Software> Software { get; set; } = null!;
        public DbSet<SoftwareSyntax> SoftwareSyntaxes { get; set; } = null!;
        public DbSet<Syntax> Syntaxes { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilterListsDbContext).Assembly);
        }
    }
}