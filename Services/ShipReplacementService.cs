using BettyBattleships.Interfaces;
using BettyBattleships.Models;
using Microsoft.Extensions.Options;

namespace BettyBattleships.Services;

public class ShipPlacementService : IShipPlacementService
{
    private readonly IRandomProvider _random;
    public ShipPlacementService(IRandomProvider random)
    {
        _random = random;
    }

    public void PlaceFleet(Board board)
    {
        var specs = new (string Name, int Length)[]
        {
            ("Carrier", 5),
            ("Battleship", 4),
            ("Cruiser", 3),
            ("Submarine", 3),
            ("Destroyer", 2)
        };

        foreach (var spec in specs)
        {
            var ship = new Ship(spec.Name, spec.Length);
            PlaceShip(board, ship);
            board.Ships.Add(ship);
        }
    }

    private void PlaceShip(Board board, Ship ship)
    {
        var size = board.Size;
        var placed = false;
        
        while (!placed)
        {
            var vertical = _random.Next(0, 2) == 1;
            var row = _random.Next(0, size);
            var col = _random.Next(0, size);

            if (vertical)
            {
                if (row + ship.Length > size) row = size - ship.Length;
            }
            else
            {
                if (col + ship.Length > size) col = size - ship.Length;
            }

            var coords = new List<Coordinate>(ship.Length);
            for (var i = 0; i < ship.Length; i++)
            {
                var c = vertical ? new Coordinate(row + i, col) : new Coordinate(row, col + i);
                coords.Add(c);
            }

            if (!Overlaps(board, coords))
            {
                ship.Positions.Clear();
                ship.Positions.AddRange(coords);
                placed = true;
            }
        }
    }

    private static bool Overlaps(Board board, IEnumerable<Coordinate> coords)
    {
        var occupied = board.Ships
            .SelectMany(s => s.Positions)
            .ToHashSet();
        
        return coords.Any(c => occupied.Contains(c));
    }
}