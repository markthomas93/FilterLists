using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

#pragma warning disable 1591

namespace FilterLists.Api.Odata
{
    public static class EdmModelFactory
    {
        public static IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<WeatherForecast>("WeatherForecast");
            return odataBuilder.GetEdmModel();
        }
    }
}