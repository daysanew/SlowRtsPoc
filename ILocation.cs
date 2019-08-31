using System.Collections.Generic;

namespace RTSGamePoc
{
    public interface ILocation
    {
        Coordinate coordinate { get; set; }
        List<ILocation> location { get; set; }
    }
}