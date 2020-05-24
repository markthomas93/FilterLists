using System;
using GraphQL;
using GraphQL.Types;

namespace FilterLists.Api.GraphQL
{
    public class FilterListSchema : Schema
    {
        public FilterListSchema(IDependencyResolver resolver) : base(resolver)
        {
            _ = resolver ?? throw new ArgumentNullException(nameof(resolver));

            Query = resolver.Resolve<FilterListQuery>();
        }
    }
}