using System;
using System.Collections.Generic;
using System.Linq;

namespace mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine(" ");
            Console.WriteLine("Directions:");
            Console.WriteLine("I have selected two random colors (Red, Yellow, or Blue) that can repeat.");
            Console.WriteLine("Try to guess the colors I have selected in the correct order.");
            Console.WriteLine("After each guess, I will let you know how you did using the following codes:");
            Console.WriteLine("0-0 > Neither color is correct.");
            Console.WriteLine("1-0 > One color is correct but not in the correct position.");
            Console.WriteLine("1-1 > One color is correct and in the correct position.");
            Console.WriteLine("2-0 > Both colors are correct but in the wrong positions.");
            Console.WriteLine(" ");

            Random generator = new Random();
            List<int> solution = new List<int>();
            int j = 0;
            while (j < 2)
            {
                solution.Add(generator.Next(0, 3));
                ++j;
            }

            List<string> userGuess = new List<string>();

            while (hasWon(userGuess, solution) == false)
            {
                Console.WriteLine("Enter your guess(color color):");
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
                if (color.ToLower() == "red")
                {
                    userColor.Add(0);
                }
                else if (color.ToLower() == "yellow")
                {
                    userColor.Add(1);
                } else if (color.ToLower() == "blue")
                {
                    userColor.Add(2);
                }
            }

            if (userGuess.Count != 0)
            {
                int l = 0;
                int x = 0;
                int y = 0;
                
                while (l < userGuess.Count())
                {
                    int m = l + 1;
                    int n = l - 1;
                    if (l == 0)
                    {
                        if (userColor[l] == solution[l]) //color and position are correct
                        {
                            ++y;
                        }
                        if (userColor[l] == solution[m]) //color is correct, position is not
                        {
                            ++x;
                        }
                    } else
                    {
                        if (userColor[l] == solution[l]) //color and position are correct
                        {
                            ++y;
                        }
                        if (userColor[l] == solution[n]) //color is correct, position is not
                        {
                            ++x;
                        }
                    }
                    ++l;
                }
                
                if (y == 2)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Your hint is: (" + x + ", " + y + ").");
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
