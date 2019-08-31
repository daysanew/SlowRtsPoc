using System.Collections.Generic;

namespace RTSGamePoc
{
    public class Town : ILocation
    {
        public Coordinate coordinate { get; set; }
        public List<ILocation> location { get; set; }

        public Town()
        {
            location = new List<ILocation>();
        }
    }
}