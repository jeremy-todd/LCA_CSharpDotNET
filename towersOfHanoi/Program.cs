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
        public static Dictionary<string, string[]> gameBoard = new Dictionary<string, string[]>();
        public static string inputStart;
        public static string inputEnd;
        public static string movingValue;
        public static int moves = -1;
        static void Main(string[] args)
        {
            //Defining starting point of dictionary gameBoard
            gameBoard.Add("A", new string[4] { "4", "3", "2", "1" });
            gameBoard.Add("B", new string[4]);
            gameBoard.Add("C", new string[4]);

            while (gameAction(inputStart, inputEnd) == false)
            {
                Console.WriteLine("Welcome to Towers of Hanoi!");
                Console.WriteLine("");
                Console.WriteLine("Directions:");
                Console.WriteLine("Move all of the disks from A to C one at a time.");
                Console.WriteLine("You cannot place a larger disk on top of a smaller disk.");
                Console.WriteLine("Good luck!");
                Console.WriteLine("");
                foreach (KeyValuePair<string, string[]> column in gameBoard)
                {
                    Console.WriteLine("{0}: {1}  {2}  {3}  {4}", column.Key, column.Value[0], column.Value[1], column.Value[2], column.Value[3]);
                }
                Console.WriteLine("");
                Console.WriteLine("Moves - " + moves);
                Console.WriteLine("");
                Console.WriteLine("Which row do you want to move the top piece from?");
                inputStart = Console.ReadLine().ToUpper();
                Console.WriteLine("Which row do you want to move " + inputStart + " to?");
                inputEnd = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("Welcome to Towers of Hanoi!");
            Console.WriteLine("");
            Console.WriteLine("Directions:");
            Console.WriteLine("Move all of the disks from A to C one at a time.");
            Console.WriteLine("You cannot place a larger disk on top of a smaller disk.");
            Console.WriteLine("Good luck!");
            Console.WriteLine("");
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
            if (inputStart != "")
            {
                string[] tempA = new string[4];
                string[] tempB = new string[4];
                string[] tempC = new string[4];
                string[] solution = new string[4] { "4", "3", "2", "1" };

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

                if (inputStart == "A" && inputEnd == "B")
                {
                    int l = 3;
                    while (l >= 0)
                    {
                        if (tempA[l] != null)
                        {
                            movingValue = tempA[l];
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempB[m] == null)
                                {
                                    if (m > 0)
                                    {
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempB[m-1]);
                                        if (test1 > test2)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("You cannot place a larger disc on top of a smaller disc.");
                                        } else
                                        {
                                            tempA[l] = null;
                                            tempB[m] = movingValue;
                                        }
                                    }
                                    else
                                    {
                                        tempA[l] = null;
                                        tempB[m] = movingValue;
                                    }
                                    break;
                                }
                                ++m;
                            }
                            break;
                        }
                        else
                        {
                            --l;
                        }
                    }
                }
                else if (inputStart == "A" && inputEnd == "C")
                {
                    int l = 3;
                    while (l >= 0)
                    {
                        if (tempA[l] != null)
                        {
                            movingValue = tempA[l];
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempC[m] == null)
                                {
                                    if (m > 0)
                                    {
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempC[m - 1]);
                                        if (test1 > test2)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("You cannot place a larger disc on top of a smaller disc.");
                                        }
                                        else
                                        {
                                            tempA[l] = null;
                                            tempC[m] = movingValue;
                                        }
                                    }
                                    else
                                    {
                                        tempA[l] = null;
                                        tempC[m] = movingValue;
                                    }
                                    break;
                                }
                                ++m;
                            }
                            break;
                        }
                        else
                        {
                            --l;
                        }
                    }
                }
                else if (inputStart == "B" && inputEnd == "A")
                {
                    int l = 3;
                    while (l >= 0)
                    {
                        if (tempB[l] != null)
                        {
                            movingValue = tempB[l];
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempA[m] == null)
                                {
                                    if (m > 0)
                                    {
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempA[m - 1]);
                                        if (test1 > test2)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("You cannot place a larger disc on top of a smaller disc.");
                                        }
                                        else
                                        {
                                            tempB[l] = null;
                                            tempA[m] = movingValue;
                                        }
                                    }
                                    else
                                    {
                                        tempB[l] = null;
                                        tempA[m] = movingValue;
                                    }
                                    break;
                                }
                                ++m;
                            }
                            break;
                        }
                        else
                        {
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
                            movingValue = tempB[l];
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempC[m] == null)
                                {
                                    if (m > 0)
                                    {
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempC[m - 1]);
                                        if (test1 > test2)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("You cannot place a larger disc on top of a smaller disc.");
                                        }
                                        else
                                        {
                                            tempB[l] = null;
                                            tempC[m] = movingValue;
                                        }
                                    }
                                    else
                                    {
                                        tempB[l] = null;
                                        tempC[m] = movingValue;
                                    }
                                    break;
                                }
                                ++m;
                            }
                            break;
                        }
                        else
                        {
                            --l;
                        }
                    }
                }
                else if (inputStart == "C" && inputEnd == "A")
                {
                    int l = 3;
                    while (l >= 0)
                    {
                        if (tempC[l] != null)
                        {
                            movingValue = tempC[l];
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempA[m] == null)
                                {
                                    if (m > 0)
                                    {
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempA[m - 1]);
                                        if (test1 > test2)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("You cannot place a larger disc on top of a smaller disc.");
                                        }
                                        else
                                        {
                                            tempC[l] = null;
                                            tempA[m] = movingValue;
                                        }
                                    }
                                    else
                                    {
                                        tempC[l] = null;
                                        tempA[m] = movingValue;
                                    }
                                    break;
                                }
                                ++m;
                            }
                            break;
                        }
                        else
                        {
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
                            movingValue = tempC[l];
                            int m = 0;
                            while (m < 4)
                            {
                                if (tempB[m] == null)
                                {
                                    if (m > 0)
                                    {
                                        int test1 = Convert.ToInt32(movingValue);
                                        int test2 = Convert.ToInt32(tempB[m - 1]);
                                        if (test1 > test2)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("You cannot place a larger disc on top of a smaller disc.");
                                        }
                                        else
                                        {
                                            tempC[l] = null;
                                            tempB[m] = movingValue;
                                        }
                                    }
                                    else
                                    {
                                        tempC[l] = null;
                                        tempB[m] = movingValue;
                                    }
                                    break;
                                }
                                ++m;
                            }
                            break;
                        }
                        else
                        {
                            --l;
                        }
                    }
                }

                gameBoard["A"] = tempA;
                gameBoard["B"] = tempB;
                gameBoard["C"] = tempC;
                ++moves;
                Console.Clear();

                if(tempC.SequenceEqual(solution) == true ) {
                    return true;
                } else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
