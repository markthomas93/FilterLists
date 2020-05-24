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

        public string ChatUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string DescriptionSourceUrl { get; set; } = null!;
        public string DonateUrl { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string ForumUrl { get; set; } = null!;
        public string HomeUrl { get; set; } = null!;
        public string IssuesUrl { get; set; } = null!;
        public int? LicenseId { get; set; }
        public License License { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string PolicyUrl { get; set; } = null!;
        public DateTime? PublishedDate { get; set; }
        public string SubmissionUrl { get; set; } = null!;
        public int? SyntaxId { get; set; }
        public Syntax Syntax { get; set; } = null!;
        public DateTime? UpdatedDate { get; set; }
        public string ViewUrl { get; set; } = null!;
        public string ViewUrlMirror1 { get; set; } = null!;
        public string ViewUrlMirror2 { get; set; } = null!;
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