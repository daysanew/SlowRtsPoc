using System;

namespace RTSGamePoc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var mapGen = new MapGenerator(100, 1);
            var map = mapGen.GenerateLocations();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
