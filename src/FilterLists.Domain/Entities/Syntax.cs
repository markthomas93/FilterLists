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

        public string DefinitionUrl { get; set; }
        public string Name { get; set; }
        public ICollection<FilterList> FilterLists { get; set; }
        public ICollection<SoftwareSyntax> SoftwareSyntaxes { get; set; }
    }
}