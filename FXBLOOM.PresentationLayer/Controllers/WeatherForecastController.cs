using FXBLOOM.SharedKernel;
using FXBLOOM.SharedKernel.Logging.NlogFile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FXBLOOM.PresentationLayer.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILog _logger;

        public WeatherForecastController(ILog logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Produces(typeof(ResponseWrapper<WeatherForecast[]>))]
        public IActionResult Get()
        {
            var rng = new Random();
            var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(response);
        }

        [HttpPost]
        [Produces(typeof(ResponseWrapper<string>))]
        public IActionResult Post([FromBody]WeatherForecast forecast)
        {
            return Error("Endpoint is unavailable");
        }
    }
}
