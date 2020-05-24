using System.Collections.Generic;
using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class Tag : AuditableEntity
    {
        public Tag()
        {
            FilterListTags = new HashSet<FilterListTag>();
        }

        public string Description { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ICollection<FilterListTag> FilterListTags { get; }
    }
}