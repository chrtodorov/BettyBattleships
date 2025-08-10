using BettyBattleships.Models;

namespace BettyBattleships.Interfaces;

public interface IDisplayService
{
    void RenderShotBoard(Board board);
    void WriteLine(string text);
}