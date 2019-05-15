using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rock, Paper, or Scissors?");
            string input = Console.ReadLine();
            string playAgain = "yes";
            RockPaperScissors(input, playAgain);
            string gameResult = RockPaperScissors(input, playAgain);
            Console.WriteLine(gameResult);
            Console.Read();
            
        }

        public static string RockPaperScissors(string input, string playAgain)
        {
            int user = 0;
            string result = "";
            if (input == "Rock" || input == "rock")
            {
                user = 0;
            } else if (input == "Paper" || input == "paper")
            {
                user = 1;
            } else if (input == "Scissors" || input == "scissors")
            {
                user = 2;
            } else
            {
                result = "You entered an invalid entry. Please enter Rock, Paper, or Scissors.";
            }

            //Generate the Computer's selection
            Random generator = new Random();
            int compSelection = generator.Next(0, 3);

            //Judge Result

            if (user == 0 && compSelection == 0) //Rock and Rock
            { 
                result = "It's a tie! Rock and Rock.";
            } else if (user == 0 && compSelection == 1) //Rock and Paper
            {
                result = "You lose. Paper covers Rock.";
            } else if (user == 0 && compSelection == 2) //Rock and Scissors
            {
                result = "You win! Rock crushes Scissors.";
            } else if (user == 1 && compSelection == 0) //Paper and Rock
            {
                result = "You win! Paper covers Rock.";
            } else if (user == 1 && compSelection == 1) //Paper and Paper
            {
                result = " It's a tie! Paper and Paper.";
            } else if (user == 1 && compSelection == 2) //Paper and Scissors
            {
                result = "You lose. Scissors cut Paper.";
            } else if (user == 2 && compSelection == 0) //Scissors and Rock
            {
                result = "You lose. Rock crushes Scissors.";
            } else if (user == 2 && compSelection == 1) //Scissors and Paper
            {
                result = "You win! Scissors cut Paper.";
            } else if (user == 2 && compSelection == 2) //Scissors and Scissors
            {
                result = "It's a tie! Scissors and Scissors.";
            }

            return result;
        }
    }
}
