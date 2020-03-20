using DataStructures;
using System;

namespace ConsoleApp1
{
    public class Tile
    {
        public int G { get; set; }
        public int H { get; set; }
        public int F { get; set; }
        public enum TileType { Floor, Wall, Target }
        public TileType Type;
        public Tile Parent;
        public int x;
        public int y;
        private static Random rnd = new Random();


        public Tile(int xPos, int yPos)
        {
            x = xPos;
            y = yPos;
            G = 0;
            H = 0;
            F = 0;

            Type = GenerateNextTile();
        }

        private TileType GenerateNextTile()
        {

            // Ensures that the first tile always is of type "floor"
            if (x == 0 && y == 0)
            {
                return TileType.Floor;
            }

            // Ensures that the last tile always is of type "Goal"
            if (x == Map.size - 1 && y == Map.size - 1)
            {
                return TileType.Target;
            }

            //Returns random tile type
            return (TileType)rnd.Next(2);

        }

        public CustomLinkedList<Tile> FindAdjacentTiles()
        {
            CustomLinkedList<Tile> AdjacentTiles = new CustomLinkedList<Tile>();
            foreach (Tile t in Map.TilesInMap) //Finds adjacent tiles for this particular tile
            {
                bool isOrthogonal = t.x == x - 1 && t.y == y || t.x == x + 1 && t.y == y || t.x == x && t.y == y - 1 || t.x == x && t.y == y + 1;
                bool isDiagonal = t.x == x - 1 && t.y == y - 1 || t.x == x + 1 && t.y == y + 1 || t.x == x - 1 && t.y == y + 1 || t.x == x + 1 && t.y == y - 1;
                if (isDiagonal || isOrthogonal)
                {
                    if (isDiagonal)
                    {
                        t.G = 14;
                    }
                    else
                    {
                        t.G = 10;
                    }
                    
                    AdjacentTiles.AddLast(t);
                }
            }
            return AdjacentTiles;
        }


        public void DrawTile()
        {
            switch (Type)
            {
                case TileType.Floor:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('X');
                    break;
                case TileType.Wall:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('W');
                    break;
                case TileType.Target:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('T');
                    break;
                default:
                    break;
            }
        }
    }
}
