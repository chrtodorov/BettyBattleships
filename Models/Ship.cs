using BettyBattleships.Enums;

namespace BettyBattleships.Models;

public class Ship
{
    public string Name { get; set; }
    public int Length { get; set; }
    public List<Coordinate> Positions { get; set; }
    public HashSet<Coordinate> Hits { get; set; }

    public Ship(string name, int length, IEnumerable<Coordinate>? positions = null)
    {
        Name = name;
        Length = length;
        Positions = positions?.ToList() ?? new List<Coordinate>(length);
        Hits = new HashSet<Coordinate>();
    }
}