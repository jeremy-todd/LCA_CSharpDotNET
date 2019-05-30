using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace towersOfHanoi_stack
{
    class Program
    {
        //Define global variable for use throughout the application
        public static Dictionary<string, string[]> gameBoard = new Dictionary<string, string[]>();
        public static string inputStart;
        public static string inputEnd;
        public static string movingValue;
        public static int moves = 0;
        public static string[] solution = new string[4] { "4", "3", "2", "1" };

        static void Main(string[] args)
        {
            //Defining starting point of dictionary gameBoard
            gameBoard.Add("A", new string[4] { "4", "3", "2", "1" });
            gameBoard.Add("B", new string[4]);
            gameBoard.Add("C", new string[4]);

            //Loop to repeat so long as the player has not solved the Towers of Hanoi
            while (gameAction(inputStart, inputEnd) == false)
            {
                Console.WriteLine("Welcome to Towers of Hanoi!");
                Console.WriteLine("");
                Console.WriteLine("Directions:");
                Console.WriteLine("Move all of the disks from A to C one at a time.");
                Console.WriteLine("You cannot place a larger disk on top of a smaller disk.");
                Console.WriteLine("Good luck!");
                Console.WriteLine("");
                //Print the current status of the Towers of Hanoi
                foreach (KeyValuePair<string, string[]> column in gameBoard)
                {
                    Console.WriteLine("{0}: {1}  {2}  {3}  {4}", column.Key, column.Value[0], column.Value[1], column.Value[2], column.Value[3]);
                }
                Console.WriteLine("");
                //Print the number of moves the player has made so far
                Console.WriteLine("Moves - " + moves);
                Console.WriteLine("");
                Console.WriteLine("Which row do you want to move the top piece from?");
                inputStart = Console.ReadLine().ToUpper();
                Console.WriteLine("Which row do you want to move the piece from " + inputStart + " to?");
                inputEnd = Console.ReadLine().ToUpper();
            }

            //Code to print once the player has solved the Towers of Hanoi
            Console.WriteLine("Welcome to Towers of Hanoi!");
            Console.WriteLine("");
            Console.WriteLine("Directions:");
            Console.WriteLine("Move all of the disks from A to C one at a time.");
            Console.WriteLine("You cannot place a larger disk on top of a smaller disk.");
            Console.WriteLine("Good luck!");
            Console.WriteLine("");
            //Print the current status of the Towers of Hanoi
            foreach (KeyValuePair<string, string[]> column in gameBoard)
            {
                Console.WriteLine("{0}: {1}  {2}  {3}  {4}", column.Key, column.Value[0], column.Value[1], column.Value[2], column.Value[3]);
            }
            Console.WriteLine("");
            Console.WriteLine("You took " + moves + " moves to solve the Towers of Hanoi!");
            Console.Read();
        }

        public static bool gameAction(string inputStart, string inputEnd)
        {
            return false;
        }
    }
}
