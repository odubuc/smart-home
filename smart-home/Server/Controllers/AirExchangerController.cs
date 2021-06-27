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
    public class AirExchangerController : ControllerBase
    {

        public AirExchangerController()
        {
            
        }

        [HttpGet]
        public AirExchangerState Get()
        {
            var rng = new Random();
            return new AirExchangerState
            {
                State = State.OFF,
                OnTimeRemainingMinutes = rng.Next(0, 60)
            };
        }
    }
}
