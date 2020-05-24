using System;

namespace FilterLists.Domain.Entities.Common
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public int Id { get; set; }
        public DateTime? ModifiedDateUtc { get; set; }
        public DateTime? CreatedDateUtc { get; set; }
    }
}