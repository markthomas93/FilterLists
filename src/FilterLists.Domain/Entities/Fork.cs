using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class Fork : AuditableManyToManyEntity
    {
        public int ForkFilterListId { get; set; }
        public FilterList ForkFilterList { get; set; }
        public int UpstreamFilterListId { get; set; }
        public FilterList UpstreamFilterList { get; set; }
    }
}