using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class Dependent : AuditableManyToManyEntity
    {
        public int DependentFilterListId { get; set; }
        public FilterList DependentFilterList { get; set; }
        public int DependencyFilterListId { get; set; }
        public FilterList DependencyFilterList { get; set; }
    }
}