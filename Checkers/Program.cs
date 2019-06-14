using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    public struct Position
    {
        public int row {get; private set;}
        public int col {get; private set;}
        public Position (int row, int col)
    	{
            this.row = row;
            this.col = col;
	    }
    }

    public enum Color {White, Black}

    public class Checker
    {
        public string symbol {get; private set;}
        public Color team {get; private set;}
        public Position position {get; set;}

        public Checker(Color team, int row, int col) 
        {
            //Code goes here...
        }
    }

    public class Board
    {
        public List<Checker> checkers;
        public Board()
        {
            checkers = new List<Checker>();
            for (int r = 0; r < 3; r++)
            {
                for (int i =0; i < 8; i++)
                {
                    Checker c = new Checker(Color.White, r, (r + 1)%2 + i);
                    checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.Black, 5 + r, (r)%2 + i);
                    checkers.Add(c);
                }
            } 
        }

        public Checker GetChecker(Position pos)
        {
            //Code goes here...
        }

        public void RemoveChecker(Checker checker)
        {
            //Code goes here...
        }

        public void MoveChecker(Checker checker, Position pos)
        {
            //Code goes here...
        }
    }

    public class Game
    {
        private Board board;
        public Game()
        {
            this.board = new Board();
        }

        private bool CheckForWin()
        {
            //Code goes here...
        }

        public void Start()
        {
            //Code goes here...
        }

        public bool IsLegalMove(Color player, Position src, Position dest)
        {
            //Code goes here...
        }

        public bool IsCapture(Position src, Position dest)
        {
            //Code goes here...
        }

        public Checker GetCaptureChecker(Position src, Position dest)
        {
            //Code goes here...
        }

        public Position ProcessInput()
        {
            //Code goes here...
        }

        public void DrawBoard()
        {
            String[][] grid = new string[8][];
            for(int r = 0; r < 8; r++)
            {
                grid[r] = new string[8];
                for(int c = 0; c < 8; c++)
                {
                    grid[r][c] = " ";
                }
            }
            foreach(Checker c in board.checkers)
            {
                grid[c.position.row][c.position.col] = c.symbol;
            }

            Console.WriteLine("  0 1 2 3 4 5 6 7");
            for(int r = 0; r < 8; r++)
            {
                Console.WriteLine(r);
                for(int c = 0; c < 8; c++)
                {
                    Console.WriteLine(" {0}", grid[r][c]);
                }
                Console.WriteLine();
            }
        }
    }
}
