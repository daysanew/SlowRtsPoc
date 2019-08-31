using System.Collections.Generic;

namespace RTSGamePoc
{
    public class Castle : ILocation
    {
        public Coordinate coordinate { get; set; }
        public List<ILocation> location { get; set; }

        public Castle()
        {
            location = new List<ILocation>();
        }
    }
}