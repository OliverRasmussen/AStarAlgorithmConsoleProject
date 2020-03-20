using System;
using System.Linq;
using System.Threading;
using DataStructures;

namespace ConsoleApp1
{
    public class AStar
    {
        CustomLinkedList<Tile> OpenList;
        CustomLinkedList<Tile> ClosedList;


        public AStar(Tile startTile, Tile target)
        {
            OpenList = new CustomLinkedList<Tile>();
            ClosedList = new CustomLinkedList<Tile>();
            Tile current = null;

            OpenList.AddFirst(startTile);

            while (OpenList.Count() > 0)
            {
                var lowestFValue = OpenList.Min(x => x.F);
                current = OpenList.First(x => x.F == lowestFValue);

                ClosedList.AddLast(current);

                Console.SetCursorPosition(current.x, current.y);
                Console.Write('.');
                Console.SetCursorPosition(current.x, current.y);
                Thread.Sleep(200);

                OpenList.Remove(current);

                if (ClosedList.Contains(target))
                {
                    //Done executing, may or may not have found target
                    Console.WriteLine();
                    break;
                }

                CustomLinkedList<Tile> AdjacentTiles = GetWalkableAdjacentTiles(current);

                foreach (Tile adjTile in AdjacentTiles)
                {
                    if (ClosedList.Contains(adjTile))
                    {
                        continue;
                    }

                    if (!OpenList.Contains(adjTile))
                    {
                        adjTile.H = CalculateH(adjTile.x, adjTile.y, target.x, target.y);
                        adjTile.F = adjTile.G + adjTile.H;
                        adjTile.Parent = current;

                        OpenList.AddFirst(adjTile);

                    }
                    else
                    {
                        if (adjTile.G + adjTile.H < adjTile.F)
                        {
                            adjTile.F = adjTile.G + adjTile.H;
                            adjTile.Parent = current;
                        }
                    }
                }
            }

            Console.SetCursorPosition(0, Map.size + 5);
            Console.ForegroundColor = ConsoleColor.White;
            if (current.Type == Tile.TileType.Target)
            {
                Console.WriteLine("Target reached!");
            }
            else
            {
                Console.WriteLine("Could not generate path to target!");
            }
        }

        static int CalculateH(int x, int y, int targetX, int targetY)
        {
            return Math.Abs((targetX - x) + Math.Abs(targetY - y)) * 10;
        }

        static CustomLinkedList<Tile> GetWalkableAdjacentTiles(Tile currentTile)
        {
            CustomLinkedList<Tile> WalkableTiles = new CustomLinkedList<Tile>();

            var adjTiles = currentTile.FindAdjacentTiles();

            foreach (Tile tile in adjTiles)
            {
                if (tile.Type != Tile.TileType.Wall)
                {
                    WalkableTiles.AddLast(tile);
                }
            }

            return WalkableTiles;
        }

    }



}
