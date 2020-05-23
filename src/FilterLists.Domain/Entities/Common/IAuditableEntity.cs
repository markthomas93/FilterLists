using System;

namespace FilterLists.Domain.Entities.Common
{
    public interface IAuditableEntity
    {
        DateTime? CreatedDateUtc { get; set; }
    }
}