using System;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FilterLists.Api.Infrastructure.OData
{
    public class QueryOptionApiDescriptionProvider : IApiDescriptionProvider
    {
        private readonly IModelMetadataProvider _provider;

        public QueryOptionApiDescriptionProvider(IModelMetadataProvider provider)
        {
            _provider = provider;
        }

        public int Order => 10;

        public void OnProvidersExecuting(ApiDescriptionProviderContext context)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));

            foreach (var result in context.Results)
                if (result.ActionDescriptor.EndpointMetadata.Any(m =>
                    (m as dynamic)?.TypeId?.FullName == typeof(EnableQueryAttribute).FullName))
                    AddODataParameters(result);
        }

        public void OnProvidersExecuted(ApiDescriptionProviderContext context)
        {
        }

        private void AddODataParameters(ApiDescription result)
        {
            result.ParameterDescriptions.Add(new ApiParameterDescription
            {
                ModelMetadata = _provider.GetMetadataForType(typeof(string)),
                Name = "$filter",
                Source = BindingSource.Query
            });
            result.ParameterDescriptions.Add(new ApiParameterDescription
            {
                ModelMetadata = _provider.GetMetadataForType(typeof(string)),
                Name = "$expand",
                Source = BindingSource.Query
            });
            result.ParameterDescriptions.Add(new ApiParameterDescription
            {
                ModelMetadata = _provider.GetMetadataForType(typeof(string)),
                Name = "$select",
                Source = BindingSource.Query
            });
            result.ParameterDescriptions.Add(new ApiParameterDescription
            {
                ModelMetadata = _provider.GetMetadataForType(typeof(string)),
                Name = "$orderby",
                Source = BindingSource.Query
            });
            result.ParameterDescriptions.Add(new ApiParameterDescription
            {
                ModelMetadata = _provider.GetMetadataForType(typeof(int)),
                Name = "$top",
                Source = BindingSource.Query
            });
            result.ParameterDescriptions.Add(new ApiParameterDescription
            {
                ModelMetadata = _provider.GetMetadataForType(typeof(int)),
                Name = "$skip",
                Source = BindingSource.Query
            });
            result.ParameterDescriptions.Add(new ApiParameterDescription
            {
                ModelMetadata = _provider.GetMetadataForType(typeof(bool)),
                Name = "$count",
                Source = BindingSource.Query
            });
        }
    }
}