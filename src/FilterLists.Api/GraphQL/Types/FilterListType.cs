using FilterLists.Domain.Entities;
using GraphQL.Types;

namespace FilterLists.Api.GraphQL.Types
{
    public class FilterListType : ObjectGraphType<FilterList>
    {
        public FilterListType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
        }
    }
}