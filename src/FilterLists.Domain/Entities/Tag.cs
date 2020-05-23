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

        public string Description { get; set; }
        public string Name { get; set; }
        public ICollection<FilterListTag> FilterListTags { get; set; }
    }
}