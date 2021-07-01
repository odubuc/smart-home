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
    public class WeatherIndoorController : ControllerBase
    {

        public WeatherIndoorController()
        {
            
        }

        [HttpGet]
        public WeatherIndoor Get()
        {
            var rng = new Random();
            return new WeatherIndoor
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Humidity = rng.Next(0, 100)
            };
        }
    }
}
