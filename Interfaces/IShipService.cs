using BettyBattleships.Models;

namespace BettyBattleships.Interfaces;

public interface IShipService
{
    void PlaceShips(Board board);
}