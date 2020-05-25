using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace FilterLists.Api.V1
{
    /// <summary>
    ///     The weather forecasts controller.
    /// </summary>
    /// <seealso cref="ODataController" />
    [Route("[controller]")]
    [ApiExplorerSettings]
    public class WeatherForecastController : ODataController
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        ///     Gets the weather forecasts.
        /// </summary>
        /// <returns>The weather forecasts.</returns>
        [HttpGet]
        [EnableQuery]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}