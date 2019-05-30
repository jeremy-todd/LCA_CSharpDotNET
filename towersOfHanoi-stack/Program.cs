using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace towersOfHanoi
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
            //if the player has entered a value for inputStart
            if (inputStart != null)
            {
                //Create temporary arrays used to move the disks around the board.
                string[] tempA = new string[4];
                string[] tempB = new string[4];
                string[] tempC = new string[4];

                //Populate the temporary arrays to the current status of the Towers of Hanoi
                foreach (KeyValuePair<string, string[]> column in gameBoard)
                {
                    if (column.Key == "A")
                    {
                        int i = 0;
                        while (i < column.Value.Length)
                        {
                            tempA[i] = column.Value[i];
                            ++i;
                        }
                    }
                    else if (column.Key == "B")
                    {
                        int j = 0;
                        while (j < column.Value.Length)
                        {
                            tempB[j] = column.Value[j];
                            ++j;
                        }
                    }
                    else if (column.Key == "C")
                    {
                        int k = 0;
                        while (k < column.Value.Length)
                        {
                            tempC[k] = column.Value[k];
                            ++k;
                        }
                    }
                }

                //Process the players moves
                if (inputStart == "A" && inputEnd == "B")
                {
                    //Checking which disk is in the top position in the origination column
                    int l = 3;
                    while (l >= 0)
                    {
                        if (tempA[l] != null)
                        {
                            //Setting the temporary variable movingValue to the top most disk in the user chosen column
                            movingValue = tempA[l];
                            //Checking for the first available slot in the destination column
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempB[m] == null)
                                {
                                    //Checking to make sure the move is valid. Only need to check if the first available slot is not slot 0.
                                    if (m > 0)
                                    {
                                        //Convert the disk values to strings for comparison
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempB[m - 1]);
                                        //Check if the movingValue is smaller than the disk below it
                                        if (test1 < test2)
                                        {
                                            tempA[l] = null;
                                            tempB[m] = movingValue;
                                        }
                                    }
                                    else //If slot 0 is available, no need to check if the lower disk is larger than the moving disk.
                                    {
                                        tempA[l] = null;
                                        tempB[m] = movingValue;
                                    }
                                    //Break the loop if we have an available slot for the movingValue
                                    break;
                                }
                                //Advance to the next slot in the destination column.
                                ++m;
                            }
                            //Break the loop if we have idenitified the top most disk in the origination column
                            break;
                        }
                        else
                        {
                            //If we have not found the top most disk in the origination column, go to the next location down
                            --l;
                        }
                    }
                }
                else if (inputStart == "A" && inputEnd == "C")
                {
                    //Checking which disk is in the top position in the origination column
                    int l = 3;
                    while (l >= 0)
                    {
                        if (tempA[l] != null)
                        {
                            //Setting the temporary variable movingValue to the top most disk in the user chosen column
                            movingValue = tempA[l];

                            //Checking for the first available slot in the destination column
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempC[m] == null)
                                {
                                    //Checking to make sure the move is valid. Only need to check if the first available slot is not slot 0.
                                    if (m > 0)
                                    {
                                        //Convert the disk values to strings for comparison
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempC[m - 1]);
                                        //Check if the movingValue is smaller than the disk below it
                                        if (test1 < test2)
                                        {
                                            tempA[l] = null;
                                            tempC[m] = movingValue;
                                        }
                                    }
                                    else //If slot 0 is available, no need to check if the lower disk is larger than the moving disk.
                                    {
                                        tempA[l] = null;
                                        tempC[m] = movingValue;
                                    }
                                    //Break the loop if we have an available slot for the movingValue
                                    break;
                                }
                                //Advance to the next slot in the destination column.
                                ++m;
                            }
                            //Break the loop if we have idenitified the top most disk in the origination column
                            break;
                        }
                        else
                        {
                            //If we have not found the top most disk in the origination column, go to the next location down
                            --l;
                        }
                    }
                }
                else if (inputStart == "B" && inputEnd == "A")
                {
                    //Checking which disk is in the top position in the origination column
                    int l = 3;
                    while (l >= 0)
                    {
                        if (tempB[l] != null)
                        {
                            //Setting the temporary variable movingValue to the top most disk in the user chosen column
                            movingValue = tempB[l];
                            //Checking for the first available slot in the destination column
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempA[m] == null)
                                {
                                    //Checking to make sure the move is valid. Only need to check if the first available slot is not slot 0.
                                    if (m > 0)
                                    {
                                        //Convert the disk values to strings for comparison
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempA[m - 1]);
                                        //Check if the movingValue is smaller than the disk below it
                                        if (test1 < test2)
                                        {
                                            tempB[l] = null;
                                            tempA[m] = movingValue;
                                        }
                                    }
                                    else //If slot 0 is available, no need to check if the lower disk is larger than the moving disk.
                                    {
                                        tempB[l] = null;
                                        tempA[m] = movingValue;
                                    }
                                    //Break the loop if we have an available slot for the movingValue
                                    break;
                                }
                                //Advance to the next slot in the destination column.
                                ++m;
                            }
                            //Break the loop if we have idenitified the top most disk in the origination column
                            break;
                            break;
                        }
                        else
                        {
                            //If we have not found the top most disk in the origination column, go to the next location down
                            --l;
                        }
                    }
                }
                else if (inputStart == "B" && inputEnd == "C")
                {
                    int l = 3;
                    while (l >= 0)
                    {
                        if (tempB[l] != null)
                        {
                            //Setting the temporary variable movingValue to the top most disk in the user chosen column
                            movingValue = tempB[l];
                            //Checking for the first available slot in the destination column
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempC[m] == null)
                                {
                                    //Checking to make sure the move is valid. Only need to check if the first available slot is not slot 0.
                                    if (m > 0)
                                    {
                                        //Convert the disk values to strings for comparison
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempC[m - 1]);
                                        //Check if the movingValue is smaller than the disk below it
                                        if (test1 < test2)
                                        {
                                            tempB[l] = null;
                                            tempC[m] = movingValue;
                                        }
                                    }
                                    else //If slot 0 is available, no need to check if the lower disk is larger than the moving disk.
                                    {
                                        tempB[l] = null;
                                        tempC[m] = movingValue;
                                    }
                                    //Break the loop if we have an available slot for the movingValue
                                    break;
                                }
                                //Advance to the next slot in the destination column.
                                ++m;
                            }
                            //Break the loop if we have idenitified the top most disk in the origination column
                            break;
                            break;
                        }
                        else
                        {
                            //If we have not found the top most disk in the origination column, go to the next location down
                            --l;
                        }
                    }
                }
                else if (inputStart == "C" && inputEnd == "A")
                {
                    //Checking which disk is in the top position in the origination column
                    int l = 3;
                    while (l >= 0)
                    {
                        if (tempC[l] != null)
                        {
                            //Setting the temporary variable movingValue to the top most disk in the user chosen column
                            movingValue = tempC[l];
                            //Checking for the first available slot in the destination column
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempA[m] == null)
                                {
                                    //Checking to make sure the move is valid. Only need to check if the first available slot is not slot 0.
                                    if (m > 0)
                                    {
                                        //Convert the disk values to strings for comparison
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempA[m - 1]);
                                        //Check if the movingValue is smaller than the disk below it
                                        if (test1 < test2)
                                        {
                                            tempC[l] = null;
                                            tempA[m] = movingValue;
                                        }
                                    }
                                    else //If slot 0 is available, no need to check if the lower disk is larger than the moving disk.
                                    {
                                        tempC[l] = null;
                                        tempA[m] = movingValue;
                                    }
                                    //Break the loop if we have an available slot for the movingValue
                                    break;
                                }
                                //Advance to the next slot in the destination column.
                                ++m;
                            }
                            //Break the loop if we have idenitified the top most disk in the origination column
                            break;
                            break;
                        }
                        else
                        {
                            //If we have not found the top most disk in the origination column, go to the next location down
                            --l;
                        }
                    }
                }
                else if (inputStart == "C" && inputEnd == "B")
                {
                    int l = 3;
                    while (l >= 0)
                    {
                        if (tempC[l] != null)
                        {
                            //Setting the temporary variable movingValue to the top most disk in the user chosen column
                            movingValue = tempC[l];
                            //Checking for the first available slot in the destination column
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempB[m] == null)
                                {
                                    //Checking to make sure the move is valid. Only need to check if the first available slot is not slot 0.
                                    if (m > 0)
                                    {
                                        //Convert the disk values to strings for comparison
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempB[m - 1]);
                                        //Check if the movingValue is smaller than the disk below it
                                        if (test1 < test2)
                                        {
                                            tempC[l] = null;
                                            tempB[m] = movingValue;
                                        }
                                    }
                                    else //If slot 0 is available, no need to check if the lower disk is larger than the moving disk.
                                    {
                                        tempC[l] = null;
                                        tempB[m] = movingValue;
                                    }
                                    //Break the loop if we have an available slot for the movingValue
                                    break;
                                }
                                //Advance to the next slot in the destination column.
                                ++m;
                            }
                            //Break the loop if we have idenitified the top most disk in the origination column
                            break;
                            break;
                        }
                        else
                        {
                            //If we have not found the top most disk in the origination column, go to the next location down
                            --l;
                        }
                    }
                }

                //Set the gameBoard arrays to equal the temporary arrays
                gameBoard["A"] = tempA;
                gameBoard["B"] = tempB;
                gameBoard["C"] = tempC;
                //Increment the number of moves the player has made
                ++moves;
                //Clear the console so that the console does not get super cluttered
                Console.Clear();

                //Check to see if we have a winner by comparing tempC with the solution
                if (tempC.SequenceEqual(solution) == true)
                {
                    //If tempC and solution match, we have a winner
                    return true;
                }
                else
                {
                    //If tempC and solution do not match, we do not have a winner
                    return false;
                }
            }
            else
            {
                //Player has not made a move yet so we do not have a winner
                return false;
            }
        }
    }
}