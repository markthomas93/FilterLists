using System.Collections.Generic;
using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class License : AuditableEntity
    {
        public License()
        {
            FilterLists = new HashSet<FilterList>();
        }

        public string DescriptionUrl { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool PermissiveAdaptation { get; set; }
        public bool PermissiveCommercial { get; set; }
        public ICollection<FilterList> FilterLists { get; }
    }
}