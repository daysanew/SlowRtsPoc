using System;
using System.Collections.Generic;
using System.Linq;

namespace RTSGamePoc
{
    public class MapGenerator
    {
        private readonly int _mapBoundary;
        private int[,] _map;
        private int _numberOfPlayers;
        private readonly int _regions;
        private readonly int _averageNumberTowns = 4;
        private readonly int _averageRegionSize = 20;

        public MapGenerator(int mapSize, int numberOfPlayers)
        {
            _mapBoundary = mapSize;
            _numberOfPlayers = numberOfPlayers;
            _map = new int[mapSize, mapSize];
        }
        private List<ILocation> GenerateLocations()
        {
            var random = new Random();
            var numberOfRegions = random.Next(_numberOfPlayers, _numberOfPlayers * 2);
            Coordinate currentCoordinates = new Coordinate
            {
                X = 0,
                Y = 0
            };

            for (var i = 0; i == numberOfRegions; i++)
            {

            }

            return new List<ILocation>();
        }

        private List<ILocation> GenerateRegion(Coordinate startBoundary)
        {
            var locations = new List<ILocation>();
            var random = new Random();
            var regionSize = random.Next(_averageRegionSize, _averageRegionSize * 2);
            Coordinate endBoundary = new Coordinate
            {
                X = startBoundary.X + regionSize,
                Y = startBoundary.Y + regionSize
            };

            var castle = new Castle
            {
                coordinate = new Coordinate
                {
                    X = random.Next(startBoundary.X, endBoundary.X),
                    Y = random.Next(startBoundary.Y, endBoundary.Y)
                }
            };

            locations.Add(castle);
            var numberOfTowns = random.Next(_averageNumberTowns / 2, _averageNumberTowns * 2);
            var townCount = 0;
            while (townCount < numberOfTowns)
            {
                var town = GenerateTown(startBoundary, endBoundary);
                if (!locations.Any(location => location.coordinate.X == town.coordinate.X && location.coordinate.Y == town.coordinate.Y))
                {
                    locations.Add(town);
                    townCount++;
                }
            }
            return new List<ILocation>();
        }

        private Town GenerateTown(Coordinate startBoundary, Coordinate endBoundary)
        {
            var random = new Random();
            return new Town
            {
                coordinate = new Coordinate
                {
                    X = random.Next(startBoundary.X, endBoundary.X),
                    Y = random.Next(startBoundary.Y, endBoundary.Y)
                }
            };
        }
    }

    public interface ILocation
    {
        Coordinate coordinate { get; set; }
        List<ILocation> location { get; set; }
    }

    public class Castle : ILocation
    {
        public Coordinate coordinate { get; set; }
        public List<ILocation> location { get; set; }
    }

    public class Town : ILocation
    {
        public Coordinate coordinate { get; set; }
        public List<ILocation> location { get; set; }
    }

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}