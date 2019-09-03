using System.Collections.Generic;
using RTSGamePoc;

namespace SlowRtsWebApi
{
    public class GameResponse
    {
        public List<Location> locations { get; set; }
        public List<General> generals { get; set; }
    }
}