using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
    public class AirExchangerController : ControllerBase
    {
        public static readonly string AirExchangerCacheKey = "air-exchanger-cache-key";
        private readonly IMemoryCache MemoryCache;

        public AirExchangerController(IMemoryCache memoryCache)
        {
            this.MemoryCache = memoryCache;
        }

        [HttpGet]
        public AirExchangerState Get()
        {
            return this.MemoryCache.GetOrCreate<AirExchangerState>(AirExchangerController.AirExchangerCacheKey, entry => {
                var rng = new Random();
                return new AirExchangerState
                {
                    State = State.OFF,
                    OnTimeRemainingMinutes = rng.Next(0, 60)
                };
            });
        }

        [HttpPut]
        public void Put(AirExchangerState AirExchangerState)
        {
            this.MemoryCache.Set<AirExchangerState>(AirExchangerController.AirExchangerCacheKey, AirExchangerState);
        }

    }
}
