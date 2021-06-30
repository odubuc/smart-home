using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using smart_home.Server.definitions;
using smart_home.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace smart_home.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherOutdoorController : ControllerBase
    {
        public static readonly string OutsideWeatherKey = "weather-outdoor-key";
        private readonly IMemoryCache MemoryCache;
        private readonly OpenWeatherMapSection options;

        public WeatherOutdoorController(IMemoryCache memoryCache, IOptions<OpenWeatherMapSection> options)
        {
            this.MemoryCache = memoryCache;
            this.options = options.Value;
        }

        [HttpGet]
        public async Task<WeatherOutdoor> Get()
        {
            return await this.MemoryCache.GetOrCreateAsync<WeatherOutdoor>(WeatherOutdoorController.OutsideWeatherKey, async entry => {
                var httpClient = new HttpClient();
                var OpenWeahterMap = await httpClient.GetFromJsonAsync<OpenWeatherMap_APIReturn>($"https://api.openweathermap.org/data/2.5/weather?lat={this.options.lat}&lon={this.options.lon}&units={this.options.unit}&appid={this.options.appid}");

                return new WeatherOutdoor
                {
                    TemperatureC = OpenWeahterMap.main.temp,
                    Humidity = OpenWeahterMap.main.humidity
                };
            });
        }
    }

}
