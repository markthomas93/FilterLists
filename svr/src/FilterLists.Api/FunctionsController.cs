using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilterLists.Api
{
    using static StatusCodes;

    /// <summary>
    ///     Provides unbound, utility functions.
    /// </summary>
    [ApiVersionNeutral]
    public class FunctionsController : ODataController
    {
        /// <summary>
        ///     Gets the sales tax for a postal code.
        /// </summary>
        /// <param name="postalCode">The postal code to get the sales tax for.</param>
        /// <returns>The sales tax rate for the postal code.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(double), Status200OK)]
        [ODataRoute("GetSalesTaxRate(PostalCode={postalCode})")]
        public IActionResult GetSalesTaxRate(int postalCode)
        {
            return Ok(5.6);
        }
    }
}