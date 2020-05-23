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

        public string ChatUrl { get; set; }
        public string Description { get; set; }
        public string DescriptionSourceUrl { get; set; }
        public string DonateUrl { get; set; }
        public string EmailAddress { get; set; }
        public string ForumUrl { get; set; }
        public string HomeUrl { get; set; }
        public string IssuesUrl { get; set; }
        public int? LicenseId { get; set; }
        public License License { get; set; }
        public string Name { get; set; }
        public string PolicyUrl { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string SubmissionUrl { get; set; }
        public int? SyntaxId { get; set; }
        public Syntax Syntax { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ViewUrl { get; set; }
        public string ViewUrlMirror1 { get; set; }
        public string ViewUrlMirror2 { get; set; }
        public ICollection<Dependent> DependentFilterLists { get; set; }
        public ICollection<Dependent> DependencyFilterLists { get; set; }
        public ICollection<Fork> ForkFilterLists { get; set; }
        public ICollection<Fork> UpstreamForkFilterLists { get; set; }
        public ICollection<FilterListLanguage> FilterListLanguages { get; set; }
        public ICollection<FilterListMaintainer> FilterListMaintainers { get; set; }
        public ICollection<Merge> MergeFilterLists { get; set; }
        public ICollection<Merge> UpstreamMergeFilterLists { get; set; }
        public ICollection<FilterListTag> FilterListTags { get; set; }
    }
}