using System;
using System.Collections.Generic;
using System.Linq;

namespace mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine(" ");
            Console.WriteLine("Directions:");
            Console.WriteLine("I have selected four random colors (Blue, Green, Orange, Purple, Red, or Yellow) that can repeat.");
            Console.WriteLine("Try to guess the colors I have selected in the correct order.");
            Console.WriteLine("After each guess, I will let you know how you did using the following codes:");
            Console.WriteLine("\u25CB > The color is in the solution but in the wrong position.");
            Console.WriteLine("\u25CF > The color is in the solution and in the correct position.");
            Console.WriteLine("_ > The color is not in the solution.");
            Console.WriteLine(" ");

            Random generator = new Random();
            List<int> solution = new List<int>();
            int j = 0;
            while (j < 4)
            {
                solution.Add(generator.Next(0, 6));
                ++j;
            }

            List<string> userGuess = new List<string>();

            while (hasWon(userGuess, solution) == false)
            {
                Console.WriteLine("Enter your guess(color color color color):");
                string userInput = Console.ReadLine();
                string[] userColor = userInput.Split(' ');
                int i = 0;
                userGuess.Clear();
                foreach (string color in userColor)
                {
                    userGuess.Add(userColor[i]);
                    ++i;
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("You won!");
            Console.Read();
        }

        public static bool hasWon(List<string> userGuess, List<int> solution)
        {
            List<int> userColor = new List<int>();
            foreach (string color in userGuess)
            {
                if (color.ToLower() == "blue")
                {
                    userColor.Add(0);
                } else if (color.ToLower() == "green")
                {
                    userColor.Add(1);
                } else if (color.ToLower() == "orange")
                {
                    userColor.Add(2);
                } else if (color.ToLower() == "purple")
                {
                    userColor.Add(3);
                } else if (color.ToLower() == "red")
                {
                    userColor.Add(4);
                } else if (color.ToLower() == "yellow")
                {
                    userColor.Add(5);
                }
            }

            if (userGuess.Count != 0)
            {
                int l = 0;
                bool[] correct = new bool[4] { false, false, false, false };
                string[] hint = new string[4];
                                
                while (l < userGuess.Count())
                {
                    if (userColor[l] == solution[l])
                    {
                        correct[l] = true;
                        hint[l] = "\u25CF";
                    } else
                    {
                        if (l == 0)
                        {
                            if (userColor[l] == solution[1] || userColor[l] == solution[2] || userColor[l] == solution[3])
                            {
                                hint[l] = "\u25CB";
                            }
                        } else if (l == 1)
                        {
                            if (userColor[l] == solution[0] || userColor[l] == solution[2] || userColor[l] == solution[3])
                            {
                                hint[l] = "\u25CB";
                            }
                        } else if (l == 2)
                        {
                            if (userColor[l] == solution[0] || userColor[l] == solution[1] || userColor[l] == solution[3])
                            {
                                hint[l] = "\u25CB";
                            }
                        } else if (l == 3)
                        {
                            if (userColor[l] == solution[0] || userColor[l] == solution[1] || userColor[l] == solution[2])
                            {
                                hint[l] = "\u25CB";
                            }
                        }
                    }
                    if (userColor[l] != solution[0] && userColor[l] != solution[1] && userColor[l] != solution[2] && userColor[l] != solution[3])
                    {
                        hint[l] = "_";
                    }
                    ++l;
                }
                
                if (correct[0] == true && correct[1] == true && correct [2] == true && correct[3] == true)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("[" + hint[0] + " " + hint[1] + " " + hint[2] + " " + hint[3] + "].");
                    Console.WriteLine(" ");
                    return false;
                }
            } else
            {
                return false;
            }
        }
    }
}
