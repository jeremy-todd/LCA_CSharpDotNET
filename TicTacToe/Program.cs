using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static string[] board = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static string currentPlayer = "O";
        static int moves = 0;

        static void Main(string[] args)
        {
            while(hasWon() == false && isTie() == false)
            {
                Console.Clear();
                printBoard();
                changeMarker();
                Console.WriteLine("Player " + currentPlayer + ", please select a square.");
                string input = Console.ReadLine();
                placeMark(input);
            }
            Console.Clear();
            printBoard();
            if(hasWon() == true && isTie() == false)
            {
                Console.WriteLine(currentPlayer + " wins!");
            } else if (hasWon() == false && isTie() == true)
            {
                Console.WriteLine("Game ends in a tie.");
            }
            
            Console.Read();
        }

        static void placeMark(string input)
        {
            //Method to place a marker on the board.
            int inp = Convert.ToInt32(input);
            board[inp] = currentPlayer;

            hasWon();
        }

        static bool isHorizontalWin()
        {
            //Method to determine if there is a horizontal win
            if (board[1] == board[2] && board[2] == board[3])
            {
                //Console.WriteLine("We have a winner!");
                return true;
            } else if (board[4] == board[5] && board[5] == board[6])
            {
                //Console.WriteLine("We have a winner!");
                return true;
            } else if (board[7] == board[8] && board[8] == board[9])
            {
                //Console.WriteLine("We have a winner!");
                return true;
            } else
            {
                //Console.WriteLine("We do not have a winner!");
                return false;
            }
        }
        
        static bool isVerticalWin()
        {
            //Method to determine if there is a vertical win
            if (board[1] == board[4] && board[4] == board[7])
            {
                //Console.WriteLine("We have a winner!");
                return true;
            } else if (board[2] == board[5] && board[5] == board[8])
            {
                //Console.WriteLine("We have a winner!");
                return true;
            } else if (board[3] == board[6] && board[6] == board[9])
            {
                //Console.WriteLine("We have a winner!");
                return true;
            } else
            {
                //Console.WriteLine("We do not have a winner!");
                return false;
            }
        }

        static bool isDiagonalWin()
        {
            //Method to determine if there is a diagonal win
            if (board[1] == board[5] && board[5] == board[9])
            {
                //Console.WriteLine("We have a winner!");
                return true;
            } else if (board[3] == board[5] && board[5] == board[7])
            {
                //Console.WriteLine("We have a winner!");
                return true;
            } else
            {
                //Console.WriteLine("We do not have a winner!");
                return false;
            }
        }

        static bool hasWon()
        {
            if (isHorizontalWin() == false && isVerticalWin() == false && isDiagonalWin() == false)
            {
                return false;
            } else
            {
                return true;
            }
        }

        static bool isTie()
        {
            //Method to determine if the game is a tie
            if (hasWon() == false && moves == 9)
            {
                return true;
            } else
            {
                return false;
            }
        }

        static void changeMarker()
        {
            if (currentPlayer == "X")
            {
                currentPlayer = "O";
            } else
            {
                currentPlayer = "X";
            }
            moves++;
        }

        static void printBoard()
        {
            //Method that prints the game board
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");
        }
    }
}