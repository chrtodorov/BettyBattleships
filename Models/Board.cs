namespace BettyBattleships.Models;

public class Board
{
    public int Size { get; set; }
    public List<Ship> Ships { get; set; }
    public HashSet<Coordinate> ShotsFired { get; set; }

    public Board(int size)
    {
        Size = size;
        Ships = new List<Ship>();
        ShotsFired = new HashSet<Coordinate>();
    }
}