using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class FilterListTag : AuditableManyToManyEntity
    {
        public int FilterListId { get; set; }
        public FilterList FilterList { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}