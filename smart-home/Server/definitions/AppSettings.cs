using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_home.Server.definitions
{
    public class OpenWeatherMapSection
    {
        public const string OpenWeatherMap = "OpenWeatherMap";

        public string lat { get; set; }
        public string lon { get; set; }
        public string unit { get; set; }
        public string appid { get; set; }
    }

}
