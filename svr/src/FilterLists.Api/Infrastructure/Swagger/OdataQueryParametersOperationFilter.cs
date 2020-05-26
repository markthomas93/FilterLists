using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FilterLists.Api.Infrastructure.Swagger
{
    public class OdataQueryParametersOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            _ = operation ?? throw new ArgumentNullException(nameof(operation));
            _ = context ?? throw new ArgumentNullException(nameof(context));

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"$filter", "The set of entities returned MAY be restricted through the use of the $filter System Query Option."},
                {"$select", "The $select system query option requests that the service return only the properties, open properties, related properties, actions and functions explicitly requested by the client. The service MUST return the specified content, and MAY choose to return additional information."},
                {"$top", "Only the first n records should be returned, where n is a non-negative integer value specified by the $top query option."},

                {"$orderby", "Determines what values are used to order a collection of records"},

                {"$skip", "The number of records to skip"}
            };
            foreach (var (key, value) in parameters)
                operation.Parameters.Add(new OpenApiParameter
                {
                    AllowEmptyValue = false,
                    AllowReserved = false,
                    Content = null,
                    Deprecated = false,
                    Description = value,
                    Example = null,
                    Examples = null,
                    Explode = false,
                    Extensions = null,
                    In = ParameterLocation.Query,
                    Name = key,
                    Reference = null,
                    Required = false,
                    Schema = null,
                    Style = null,
                    UnresolvedReference = false
                });
        }
    }
}