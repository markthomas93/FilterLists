using System.Collections.Generic;
using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class Maintainer : AuditableEntity
    {
        public Maintainer()
        {
            FilterListMaintainers = new HashSet<FilterListMaintainer>();
        }

        public string? EmailAddress { get; set; }
        public string? HomeUrl { get; set; }
        public string Name { get; set; } = null!;
        public string? TwitterHandle { get; set; }
        public ICollection<FilterListMaintainer> FilterListMaintainers { get; }
    }
}