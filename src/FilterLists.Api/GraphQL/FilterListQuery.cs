using FilterLists.Api.GraphQL.Types;
using FilterLists.Infrastructure.Persistence;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace FilterLists.Api.GraphQL
{
    public class FilterListQuery : ObjectGraphType
    {
        public FilterListQuery(FilterListsDbContext dbContext)
        {
            Field<ListGraphType<FilterListType>>(
                "filterLists",
                resolve: context => dbContext.FilterLists.ToListAsync());
        }
    }
}