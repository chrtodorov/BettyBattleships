namespace BettyBattleships.Interfaces;

public interface IRandomProvider
{
    int Next(int minInclusive, int maxExclusive);
}