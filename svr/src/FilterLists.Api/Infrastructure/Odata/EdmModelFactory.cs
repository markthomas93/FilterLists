using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace FilterLists.Api.Infrastructure.Odata
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