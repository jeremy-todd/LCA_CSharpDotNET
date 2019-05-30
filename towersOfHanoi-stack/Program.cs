using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace towersOfHanoi_stack
{
    class Program
    {
        //Define global variables for use throughout the application
        public static Dictionary<string, Stack<int>> gameBoard = new Dictionary<string, Stack<int>>();
        public static string inputStart;
        public static string inputEnd;
        public static Stack<int> columnStart;
        public static Stack<int> columnEnd;
        public static int moves = 0;
        public static Stack<int> columnA = new Stack<int>();
        public static Stack<int> columnB = new Stack<int>();
        public static Stack<int> columnC = new Stack<int>();

        static void Main(string[] args)
        {
            //Add starting values to columnA
            int i = 4;
            while (i > 0)
            {
                columnA.Push(i);
                --i;
            }

            //Defining starting point of dictionary gameBoard
            gameBoard.Add("A", columnA);
            gameBoard.Add("B", columnB);
            gameBoard.Add("C", columnC);

            //Loop to repeat so long as the player has not solved the Towers of Hanoi
            while (GameAction(inputStart, inputEnd) == false)
            {
                Console.WriteLine("Welcome to Towers of Hanoi!");
                Console.WriteLine("");
                Console.WriteLine("Directions:");
                Console.WriteLine("Move all of the disks from A to C one at a time.");
                Console.WriteLine("You cannot place a larger disk on top of a smaller disk.");
                Console.WriteLine("Good luck!");
                Console.WriteLine("");
                //Print the current status of the Towers of Hanoi
                foreach (KeyValuePair<string, Stack<int>> column in gameBoard)
                {
                    //Create a variable to populate with the values of each stack.
                    string colLabel = string.Empty;
                    //Loop through each stack and add the values to colLabel.
                    foreach (int disk in column.Value.Reverse())
                    {
                        colLabel += disk + " ";
                    }
                    //Print the gameBoard on the Console
                    Console.WriteLine("{0}: {1}", column.Key[0], colLabel);
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
            foreach (KeyValuePair<string, Stack<int>> column in gameBoard)
            {
                //Create a variable to populate with the values of each stack.
                string colLabel = string.Empty;
                //Loop through each stack and add the values to colLabel.
                foreach (int disk in column.Value.Reverse())
                {
                    colLabel += disk + " ";
                }
                //Print the gameBoard on the Console
                Console.WriteLine("{0}: {1}", column.Key[0], colLabel);
            }
            Console.WriteLine("");
            //Print the number of moves the player has made so far
            Console.WriteLine("You solved Towers of Hanoi in " + moves + " moves!");
            Console.Read();
        }

        public static bool GameAction(string inputStart, string inputEnd)
        {
            //if the player has entered a value for inputStart
            if (inputStart != null)
            {
                //Create a variable that determines if the player entered the same column for start and end
                bool sameColumn = false;
                if (inputStart == "A") //What to do if the player selects column A as the origination column
                {
                    columnStart = columnA; //tempStack set to match columnA
                    if (inputEnd == "A") //What to do if the player selected column A as the destination column
                    {
                        ++moves;
                        sameColumn = true;
                    }
                    else if (inputEnd == "B") //What to do if the players selects column B as the destination column
                    {
                        columnEnd = columnB;
                    }
                    else if (inputEnd == "C") //What to do if the players selects column B as the destination column
                    {
                        columnEnd = columnC;
                    }
                }
                else if (inputStart == "B") //What to do if the player selects column B as the origination column
                {
                    columnStart = columnB;
                    if (inputEnd == "A") //What to do if the player selected column A as the destination column
                    {
                        columnEnd = columnA;
                    }
                    else if (inputEnd == "B") //What to do if the players selects column B as the destination column
                    {
                        ++moves;
                        sameColumn = true;
                    }
                    else if (inputEnd == "C") //What to do if the players selects column B as the destination column
                    {
                        columnEnd = columnC;
                    }
                }
                else if (inputStart == "C") //What to do if the player selects column C as the origination column
                {
                    columnStart = columnC;
                    if (inputEnd == "A") //What to do if the player selected column A as the destination column
                    {
                        columnEnd = columnA;
                    }
                    else if (inputEnd == "B") //What to do if the players selects column B as the destination column
                    {
                        columnEnd = columnB;
                    }
                    else if (inputEnd == "C") //What to do if the players selects column B as the destination column
                    {
                        ++moves;
                        sameColumn = true;
                    }
                }

                if (sameColumn == false) //Process this code if the origination column and destination column are not the same.
                {
                    if (ValidMove(columnStart, columnEnd) == true) //Call the method ValidMove and pass the columnStart and columnEnd
                    {
                        if(columnStart.Count() != 0) //What to do if the origination column is not empty - Do nothing if it is empty.
                        {
                            columnEnd.Push(columnStart.Pop());
                        }
                        
                        if (inputStart == "A") //What to do if the move is valid and the origination column is column A
                        {
                            columnA = columnStart;
                        }
                        else if (inputStart == "B") //What to do if the move is valid and the origination column is column B
                        {
                            columnB = columnStart;
                        }
                        else if (inputStart == "C") //What to do if the move is valid and the origination column is column C
                        {
                            columnC = columnStart;
                        }

                        if (inputEnd == "A") //What to do if the move is valid and the destination column is column A
                        {
                            columnA = columnEnd;
                        }
                        else if (inputEnd == "B") //What to do if the move is valid and the destination column is column B
                        {
                            columnB = columnEnd;
                        }
                        else if (inputEnd == "C") //What to do if the move is valid and the destination column is column C
                        {
                            columnC = columnEnd;
                        }
                    }
                }
            }

            Console.Clear(); //Clear the console so that the console does not get super cluttered
            return GameWon(); //Call GameWon method and return the result.
        }

        public static bool ValidMove(Stack<int> columnStart, Stack<int> columnEnd) //Return if the move is valid (true) or not (false)
        {
            if (columnStart.Count() != 0 && columnEnd.Count() != 0) //What to do if both origination and destination columns are not empty - do nothing if both are empty.
            {
                ++moves; //Add a move to the player's tally

                if (columnStart.Peek() < columnEnd.Peek()) //Check to make sure the disk being moved is smaller than the disk it is going on top of.
                {
                    return true; //Disk being moved is smaller than the disk it is going on top of. Valid move.
                }
                else
                {
                    return false; //Disk being moved is larger than the disk it is going on top of. Invalid move.
                }

            } else //What do if the destination column is empty
            {
                ++moves; //Add a move to the player's tally.
                return true; //The destination column is empty. Valid move.
            }
        }

        public static bool GameWon() //Return if the player has solved Towers of Hanoi (true) or not (false). 
        {
            if(columnC.Count() == 4) //Check the count of column C
            {
                return true; //Player has solved the Towers of Hanoi because the count is 4.
            } else
            {
                return false; //Player has not solved the Towers of Hanoi because the count is not 4.
            }
        }
    }
}