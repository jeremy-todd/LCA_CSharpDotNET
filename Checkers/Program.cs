using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class ProgramCheck
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Checkers.Game game = new Game();
            //game.CheckerStartingPoint();
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
            Row = row;
            Col = col;
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
                int symbol = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber); //open circle
                Symbol = char.ConvertFromUtf32(symbol);
                Team = Color.White;
            }
            else
            {
                int symbol = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber); //closed circle
                Symbol = char.ConvertFromUtf32(symbol);
                Team = Color.Black;
            }
            Position = new Position(row, col);
        }
    }
    #endregion

    #region Class Board
    public class Board
    {
        public List<Checker> checkers {get; private set;}
        
        #region Constructors
        public Board()
        {
            checkers = new List<Checker>();
            for (int r = 0; r < 3; r++)
            {
                for (int i = 0; i < 8; i += 2)
                {
                    // the first three rows are for White checkers (row = 0,1,2)
                    // the last three rows are for Black checkers (row = 5,6,7)
                    Checker cw = new Checker(Color.White, r, (r + 1) % 2 + i);
                    Checker cb = new Checker(Color.Black, (r + 5), (r) % 2 + i);
                    checkers.Add(cw);
                    checkers.Add(cb);
                }
            }
        }
        #endregion

        #region Methods
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

        public void MoveChecker(Checker checker, Position destination)
        {
            Checker c = new Checker(checker.Team, destination.Row, destination.Col);
            checkers.Add(c);
            checkers.Remove(checker);
        }
        #endregion
    }
    #endregion

    #region Class Game
    public class Game
    {
        public Board board;
        public Game()
        {
            board = new Board();
        }

        #region Methods
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
            Console.WriteLine("Press any key to exit.");
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
            Checker cs = board.GetChecker(src);
            Checker cd = board.GetChecker(dest);
            if (cs == null)
            {
                return false;
            }
            //4.2 There must not be a checker at the dest position
            if (cd != null)
            {
                return false;
            }

            //5. Now we need to make sure the moving direction and length
            if (rowDistance == 2)
            {
                if (IsCapture(src, dest))
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

        public bool IsCapture(Position src, Position dest)
        {
            int RowDistance = Math.Abs(dest.Row - src.Row);
            int ColDistance = Math.Abs(dest.Col - src.Col);
            if(RowDistance == 2 && ColDistance == 2)
            {
                //there must be a piece in the middle of the source and the destination
                int row_mid = (dest.Row + src.Row) / 2;
                int col_mid = (dest.Col + src.Col) / 2;
                Position p = new Position(row_mid, col_mid);
                Checker c = board.GetChecker(p);
                Checker player = board.GetChecker(src);
                if (c == null)
                {
                    return false;
                }
                else
                {
                    if (c.Team == player.Team)
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
            if(IsCapture(src, dest))
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

        public void ProcessInput()
        {
            Console.WriteLine("Select a checker to move (Row, Column):");
            string[] source = Console.ReadLine().Split(',');
            Console.WriteLine("Select a square to move the checker to (Row, Column):");
            string[] destination = Console.ReadLine().Split(',');
            Position from = new Position(int.Parse(source[0]), int.Parse(source[1]));
            Position to = new Position(int.Parse(destination[0]), int.Parse(destination[1]));
            Checker c = board.GetChecker(from);
            if (c != null)
            {
                if (IsLegalMove(c.Team, from, to))
                {
                    if (IsCapture(from, to))
                    {
                        Checker captured = GetCaptureChecker(c.Team, from, to);
                        board.RemoveChecker(captured);
                    }
                    board.MoveChecker(c, to);
                    DrawBoard();
                }
                else
                {
                    Console.WriteLine("That is an invalid move, Please double check your source and destination.");
                }
            }
            else
            {
                Console.WriteLine("That is an invalid move, Please double check your source and destination.");
            }
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

            Console.WriteLine("    0   1   2   3   4   5   6   7");
            Console.Write("  ");
            for(int i = 0; i < 33; i++)
            {
                Console.Write("\u2501");
            }
            Console.WriteLine();

            for(int r = 0; r < 8; r++)
            {
                Console.Write($"{r} \u2503");
                for(int c = 0; c < 8; c++)
                {
                    Console.Write($" {grid[r][c]} \u2503");
                }
                Console.WriteLine();
                Console.Write("  ");
                for (int i = 0; i < 33; i++)
                {
                    Console.Write("\u2501");
                }
                Console.WriteLine("");
            }
        }

        public void CheckerStartingPoint()
        {
            foreach (Checker c in board.checkers)
            {
                Console.WriteLine("{0} - ({1}, {2})",c.Team,c.Position.Row,c.Position.Col);
            }
        }
        #endregion
    }
    #endregion
}