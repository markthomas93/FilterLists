using System;

namespace FilterLists.Domain.Entities.Common
{
    public abstract class AuditableManyToManyEntity : IAuditableEntity
    {
        public DateTime? CreatedDateUtc { get; set; }
    }
}