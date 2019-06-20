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
            game.DrawBoard();
            Console.Read();
        }
    }

    public struct Position
    {
        public int Row {get; private set;}
        public int Col {get; private set;}
        public Position (int row, int col)
    	{
            this.Row = row;
            this.Col = col;
	    }
    }

    public enum Color {White, Black }

    #region Class Checker
    public class Checker
    {
        public string Symbol {get; private set;}
        public Color Team {get; private set;}
        public Position Position {get; set;}

        public Checker(Color team, int row, int col) 
        {
            if(team == Color.White)
            {
                Symbol = "25CF"; //open circle
                Team = Color.White;
            }
            else
            {
                Symbol = "25CB"; //filled circle
                Team = Color.Black;
            }
        }
    }
    #endregion

    #region Class Board
    public class Board
    {
        public List<Checker> checkers;
        public Board()
        {
            checkers = new List<Checker>();
            for (int r = 0; r < 3; r++)
            {
                for (int i =0; i < 8; i++) //Adding starting white checkers to the game board
                {
                    Checker c = new Checker(Color.White, r, (r + 1) % 2 + i);
                    checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2) //Adding starting black checkers to the game board
                {
                    Checker c = new Checker(Color.Black, 5 + r, (r) % 2 + i);
                    checkers.Add(c);
                }
            } 
        }

        public Checker GetChecker(Position pos)
        {
            ///TODO: Use LINQ to implement this function
            foreach (Checker c in checkers)
            {
                if(c.Position.Row == pos.Row && c.Position.Col == pos.Col)
                {
                    return c;
                }
            }
            return null;
        }

        public void RemoveChecker(Checker checker)
        {
            if(checker != null)
            {
                checkers.Remove(checker);
            }
            ///TODO: what if checker == null?
        }

        public void MoveChecker(Checker checker, Position pos)
        {
            Checker c = new Checker(checker.Team, pos.Row, pos.Col);
            checkers.Add(c);
            RemoveChecker(checker);
        }
    }
    #endregion

    #region Class Game
    public class Game
    {
        private Board board;
        public Game()
        {
            this.board = new Board();
        }

        private bool CheckForWin()
        {
            return board.checkers.All(x => x.Team == Color.White) || board.checkers.All(x => x.Team == Color.Black);
        }

        public void Start()
        {
            DrawBoard();
            while(!CheckForWin())
            {
                this.ProcessInput();
            }
            Console.WriteLine("You won!");
            Console.Read();
        }

        public bool IsLegalMove(Color player, Position src, Position dest)
        {
            //1. Both the src and dest must be integers between 0 and 7.
            if(src.Row < 0 || src.Row > 7 || src.Col < 0 || src.Col > 7 || dest.Row < 0
                || dest.Row > 7 || dest.Col < 0 || dest.Col > 7)
            {
                return false;
            }

            //2. The dest point and the src point must fall on the same line with
            //the slope = 1 or slope = -1. Or the ABS of the slope must be 1.
            int rowDistance = Math.Abs(dest.Row - src.Row);
            int colDistance = Math.Abs(dest.Col - src.Col);
            //Check to make sure the move is not directly horizontal or directly vertical
            if(rowDistance == 0 || colDistance == 0)
            {
                return false;
            }
            if(rowDistance / colDistance != 1)
            {
                return false;
            }

            //3. If we reach here, that means the dest position and the src position
            //are on the same line. But we need to make sure the dest can only be up to
            //2 steps away from the src (if there is a piece in between).
            if(rowDistance > 2) //No need to check colDistance because rowDistance and colDistance are equal.
            {
                return false;
            }

            //4. Now we have made sure that the dest position and src position are on the same
            //line and with the correct distance.
            //4.1 There must be a checker at the src position
            Checker c = board.GetChecker(src);
            if (c == null)
            {
                return false;
            }
            //4.2 There must not be a checker at the dest position
            if (c != null)
            {
                return false;
            }

            //5. Now we need to make sure the moving direction and length
            if (rowDistance == 2)
            {
                if (IsCapture(player, src, dest))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool IsCapture(Color player, Position src, Position dest)
        {
            int RowDistance = Math.Abs(dest.Row - src.Row);
            int ColDistance = Math.Abs(dest.Col - src.Col);
            if(RowDistance == 2 && ColDistance == 2)
            {
                int row_mid = (dest.Row + src.Row) / 2;
                int col_mid = (dest.Col + src.Col) / 2;
                Position p = new Position(row_mid, col_mid);
                Checker c = board.GetChecker(p);
                if (c == null)
                {
                    return false;
                }
                else
                {
                    if (c.Team == player)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public Checker GetCaptureChecker(Color player, Position src, Position dest)
        {
            if(IsCapture(player,src,dest))
            {
                int row_mid = (dest.Row + src.Row) / 2;
                int col_mid = (dest.Col + src.Col) / 2;
                Position p = new Position(row_mid, col_mid);
                Checker c = board.GetChecker(p);
                return c;
            }
            else
            {
                return null;
            }
        }

        public Position ProcessInput()
        {
            //Do something here...
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
                grid[c.Position.Row][c.Position.Col] = c.Symbol;
            }

            Console.WriteLine("  0  1  2  3  4  5  6  7");
            Console.WriteLine("  ");
            for(int i = 0; i < 32; i++)
            {
                Console.WriteLine("\u2501");
            }
            Console.WriteLine("");
            for(int r = 0; r < 8; r++)
            {
                Console.WriteLine(r);
                for(int c = 0; c < 8; c++)
                {
                    Console.WriteLine($"  {grid[r][c]} \u2503");
                }
                Console.WriteLine();
                Console.WriteLine("  ");
                for (int i = 0; i < 32; i++)
                {
                    Console.WriteLine("\u2501");
                }
                Console.WriteLine("");
            }
        }
    }
    #endregion
}
