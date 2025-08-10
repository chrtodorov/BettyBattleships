using BettyBattleships.Models;

namespace BettyBattleships.Interfaces;

public interface IShipPlacementService
{
    void PlaceFleet(Board board);
}