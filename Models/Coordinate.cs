namespace BettyBattleships.Models;

public readonly record struct Coordinate
{
    public int Row { get; }
    public int Col { get; }
    public Coordinate(int row, int col)
    {
        Row = row;
        Col = col;
    }
}