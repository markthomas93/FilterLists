using System.Collections.Generic;
using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class Syntax : AuditableEntity
    {
        public Syntax()
        {
            FilterLists = new HashSet<FilterList>();
            SoftwareSyntaxes = new HashSet<SoftwareSyntax>();
        }

        public string DefinitionUrl { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ICollection<FilterList> FilterLists { get; }
        public ICollection<SoftwareSyntax> SoftwareSyntaxes { get; }
    }
}