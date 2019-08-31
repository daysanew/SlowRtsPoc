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
        private readonly int _averageRegionSize = 10;

        public MapGenerator(int mapSize, int numberOfPlayers)
        {
            _mapBoundary = mapSize;
            _numberOfPlayers = numberOfPlayers;
            _map = new int[mapSize, mapSize];
        }
        public char[,] GenerateLocations()
        {
            var random = new Random();
            var numberOfRegions = random.Next(_numberOfPlayers, _numberOfPlayers * 2);
            Coordinate currentCoordinates = new Coordinate
            {
                X = 0,
                Y = 0
            };

            var regions = new List<ILocation>();
            for (var i = 1; i <= numberOfRegions; i++)
            {
                var towns = GenerateRegion(currentCoordinates);

                currentCoordinates.X = towns.Select(town => town.coordinate.X).Max();
                currentCoordinates.Y = towns.Select(town => town.coordinate.Y).Max();

                regions.AddRange(towns);
            }

            return TurnRegionsIntoArray(regions);
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
                    locations.Last().location.Add(town);
                    town.location.Add(locations.Last());
                    locations.Add(town);
                    townCount++;
                }
            }
            return locations;
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

        private char[,] TurnRegionsIntoArray(List<ILocation> locations)
        {
            var maxX = locations.Select(town => town.coordinate.X).Max() + 5;
            var maxY = locations.Select(town => town.coordinate.Y).Max() + 5;
            var map = new char[maxX, maxY];
            for (var x = 0; x < maxX; x++)
            {
                for (var y = 0; y < maxY; y++)
                {
                    map[x, y] = '-';
                }
            }

            locations.ForEach(location =>
            {
                if (location.GetType() == typeof(Castle))
                {
                    map[location.coordinate.X, location.coordinate.Y] = 'C';
                }
                else
                {
                    map[location.coordinate.X, location.coordinate.Y] = 'T';
                }
            });

            return map;
        }
    }
}