using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using smart_home.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_home.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherOutdoorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherOutdoorController()
        {
        }

        [HttpGet]
        public IEnumerable<WeatherOutdoor> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherOutdoor
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
