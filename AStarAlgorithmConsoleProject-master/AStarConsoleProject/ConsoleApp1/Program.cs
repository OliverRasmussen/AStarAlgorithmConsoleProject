using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AStar aStar;
            Map map;
            Char userInput;

            while (true)
            {

                map = new Map();
                map.GenerateMap();

                Console.SetCursorPosition(0, Map.size + 1);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("X = Floor");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("W = Wall");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("T = Target");

                aStar = new AStar(Map.TilesInMap.First(), Map.TilesInMap.Last());

                
                Console.WriteLine("Try again: y/n");
                userInput = Console.ReadKey().KeyChar;

                if (userInput == 'y')
                {
                    Console.Clear();
                }
                else
                {
                    Environment.Exit(-1);
                }

            }
        }
    }
}
