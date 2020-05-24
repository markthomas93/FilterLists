using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class FilterListMaintainer : AuditableManyToManyEntity
    {
        public int FilterListId { get; set; }
        public FilterList FilterList { get; set; } = null!;
        public int MaintainerId { get; set; }
        public Maintainer Maintainer { get; set; } = null!;
    }
}