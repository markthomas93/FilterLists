using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class FilterListLanguage : AuditableManyToManyEntity
    {
        public int FilterListId { get; set; }
        public FilterList FilterList { get; set; } = null!;
        public int LanguageId { get; set; }
        public Language Language { get; set; } = null!;
    }
}