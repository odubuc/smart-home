using System;
using System.Collections.Generic;
using System.Text;

namespace smart_home.Shared
{
    public enum State
    {
        ON = 1,
        OFF = 2
    }

    public class AirExchangerState
    {
        public State State { get; set; }

        public int OnTimeRemainingMinutes { get; set; }
    }

    
}
