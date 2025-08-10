using BettyBattleships.Enums;
using BettyBattleships.Interfaces;
using BettyBattleships.Models;

namespace BettyBattleships.Services;

public class ShotResolutionService : IShotResolutionService
{
    public (ShotResult Result, string Message) ResolveShot(Board board, Coordinate shot)
    {
        if (board.ShotsFired.Contains(shot))
        {
            return (ShotResult.Miss, "You already fired at that coordinate. Try a new one.");
        }

        board.ShotsFired.Add(shot);
        foreach (var ship in board.Ships)
        {
            if (ship.Positions.Contains(shot))
            {
                ship.Hits.Add(shot);
                if (ship.Hits.Count == ship.Length)
                {
                    return (ShotResult.Sunk, $"Ship Sunk: {ship.Name}!");
                }
                return (ShotResult.Hit, "Hit!");
            }
        }
        return (ShotResult.Miss, "Miss.");
    }

    public bool AllShipsSunk(Board board) => board.Ships.All(s => s.Hits.Count == s.Length);
}