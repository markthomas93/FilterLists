using System;
using System.Collections.Generic;
using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class FilterList : AuditableEntity
    {
        public FilterList()
        {
            DependentFilterLists = new HashSet<Dependent>();
            DependencyFilterLists = new HashSet<Dependent>();
            ForkFilterLists = new HashSet<Fork>();
            UpstreamForkFilterLists = new HashSet<Fork>();
            FilterListLanguages = new HashSet<FilterListLanguage>();
            FilterListMaintainers = new HashSet<FilterListMaintainer>();
            MergeFilterLists = new HashSet<Merge>();
            UpstreamMergeFilterLists = new HashSet<Merge>();
            FilterListTags = new HashSet<FilterListTag>();
        }

        public string? ChatUrl { get; set; }
        public string? Description { get; set; }
        public string? DescriptionSourceUrl { get; set; }
        public string? DonateUrl { get; set; }
        public string? EmailAddress { get; set; }
        public string? ForumUrl { get; set; }
        public string? HomeUrl { get; set; }
        public string? IssuesUrl { get; set; }
        public int? LicenseId { get; set; }
        public License License { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? PolicyUrl { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? SubmissionUrl { get; set; }
        public int? SyntaxId { get; set; }
        public Syntax Syntax { get; set; } = null!;
        public DateTime? UpdatedDate { get; set; }
        public string? ViewUrl { get; set; }
        public string? ViewUrlMirror1 { get; set; }
        public string? ViewUrlMirror2 { get; set; }
        public ICollection<Dependent> DependentFilterLists { get; }
        public ICollection<Dependent> DependencyFilterLists { get; }
        public ICollection<Fork> ForkFilterLists { get; }
        public ICollection<Fork> UpstreamForkFilterLists { get; }
        public ICollection<FilterListLanguage> FilterListLanguages { get; }
        public ICollection<FilterListMaintainer> FilterListMaintainers { get; }
        public ICollection<Merge> MergeFilterLists { get; }
        public ICollection<Merge> UpstreamMergeFilterLists { get; }
        public ICollection<FilterListTag> FilterListTags { get; }
    }
}