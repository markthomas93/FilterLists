using FilterLists.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilterLists.Data
{
    public class FilterListsDbContext : DbContext
    {
        public FilterListsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<FilterList> FilterLists { get; set; }
        public DbSet<FilterListLanguage> FilterListLanguages { get; set; }
        public DbSet<FilterListMaintainer> FilterListMaintainers { get; set; }
        public DbSet<FilterListTag> FilterListTags { get; set; }
        public DbSet<Fork> Forks { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Maintainer> Maintainers { get; set; }
        public DbSet<Merge> Merges { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<SoftwareSyntax> SoftwareSyntaxes { get; set; }
        public DbSet<Syntax> Syntaxes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilterListsDbContext).Assembly);
        }
    }
}