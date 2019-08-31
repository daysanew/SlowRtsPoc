using System.Collections.Generic;
using RTSGamePoc;

namespace SlowRtsWebApi
{
    public class Location
    {
        public string type { get; set; }
        public Coordinate coordinate { get; set; }
        public List<Coordinate> connectedLocations { get; set; }
    }
}