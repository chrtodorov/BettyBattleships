using BettyBattleships.Enums;
using BettyBattleships.Models;

namespace BettyBattleships.Interfaces;

public interface IShotResolutionService
{
    (ShotResult Result, string Message) ResolveShot(Board board, Coordinate shot);
    bool AllShipsSunk(Board board);
}