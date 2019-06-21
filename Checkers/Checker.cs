using System;

/// <summary>
/// Summary description for Checker
/// </summary>
public class Checker
{
    public string Symbol { get; private set; }
    public Color Team { get; private set; }
    public Position Position { get; set; }

    public Checker(Color team, int row, int col)
    {
        if (team == Color.White)
        {
            int symbol = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber); //open circle
            Symbol = char.ConvertFromUtf32(symbol);
            Team = Color.Black;
        }
        else
        {
            int symbol = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber); //closed circle
            Symbol = char.ConvertFromUtf32(symbol);
            Team = Color.Black;
        }
    }
}
