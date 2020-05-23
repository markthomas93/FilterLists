using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class Merge : AuditableManyToManyEntity
    {
        public int MergeFilterListId { get; set; }
        public FilterList MergeFilterList { get; set; }
        public int UpstreamFilterListId { get; set; }
        public FilterList UpstreamFilterList { get; set; }
    }
}