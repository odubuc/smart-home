using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;

namespace smart_home.Shared
{
    public class WeatherIndoor
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int Humidity { get; set; }
    }
}
