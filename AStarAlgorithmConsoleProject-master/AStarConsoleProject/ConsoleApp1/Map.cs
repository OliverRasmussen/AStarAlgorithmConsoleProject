using DataStructures;
using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Map
    {
        public static CustomLinkedList<Tile> TilesInMap { get; private set; }


        public Map()
        {
           TilesInMap = new CustomLinkedList<Tile>();
        }

        public const int size = 15;
        

        public void GenerateMap()
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    TilesInMap.AddLast(new Tile(x, y));
                }
            }
            DrawMap();
        }

        

        public void DrawMap()
        {
            int i = 0;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Tile t = TilesInMap.ElementAt(i);
                    t.DrawTile();
                    i++;
                }
                Console.WriteLine();
            }
        }
    }
}
