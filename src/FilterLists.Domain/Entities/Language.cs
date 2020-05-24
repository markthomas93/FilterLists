using System.Collections.Generic;
using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class Language : AuditableEntity
    {
        public Language()
        {
            FilterListLanguages = new HashSet<FilterListLanguage>();
        }

        public string Iso6391 { get; set; } = null!;
        public string Iso6392 { get; set; } = null!;
        public string Iso6392B { get; set; } = null!;
        public string Iso6392T { get; set; } = null!;
        public string Iso6393 { get; set; } = null!;
        public string LocalName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ICollection<FilterListLanguage> FilterListLanguages { get; }
    }
}