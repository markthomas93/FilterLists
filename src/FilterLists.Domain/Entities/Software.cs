using System.Collections.Generic;
using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class Software : AuditableEntity
    {
        public Software()
        {
            SoftwareSyntaxes = new HashSet<SoftwareSyntax>();
        }

        public string DownloadUrl { get; set; } = null!;
        public string HomeUrl { get; set; } = null!;
        public bool IsAbpSubscribable { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<SoftwareSyntax> SoftwareSyntaxes { get; }
    }
}