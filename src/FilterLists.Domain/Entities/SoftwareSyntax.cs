using FilterLists.Domain.Entities.Common;

namespace FilterLists.Domain.Entities
{
    public class SoftwareSyntax : AuditableManyToManyEntity
    {
        public int SoftwareId { get; set; }
        public Software Software { get; set; }
        public int SyntaxId { get; set; }
        public Syntax Syntax { get; set; }
    }
}