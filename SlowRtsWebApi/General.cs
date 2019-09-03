using System;
using RTSGamePoc;

namespace SlowRtsWebApi
{
    public class General
    {
        public string name { get; set; }
        public Coordinate location { get; set; }
        public Coordinate destination { get; set; }
        public int speed { get; set; }
        public DateTime startTime { get; set; }
        public DateTime arrivalTime { get; set; }
    }
}