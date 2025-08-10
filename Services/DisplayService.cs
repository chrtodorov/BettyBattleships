using BettyBattleships.Interfaces;
using BettyBattleships.Models;

namespace BettyBattleships.Services;

public class DisplayService : IDisplayService
{
    public void RenderShotBoard(Board board)
    {
        Console.Clear();
        Console.WriteLine("=== Betty Battleships ===\n");

        // Header: columns 1..10
        Console.Write("   ");
        for (var c = 1; c <= board.Size; c++)
        {
            Console.Write(c.ToString().PadLeft(2));
            Console.Write(' ');
        }
        Console.WriteLine();

        // Rows A..J
        for (int r = 0; r < board.Size; r++)
        {
            char rowLabel = (char)('A' + r);
            Console.Write(rowLabel + "  ");
            for (int c = 0; c < board.Size; c++)
            {
                var coord = new Coordinate(r, c);
                char symbol = '.'; // unknown
                if (board.ShotsFired.Contains(coord))
                {
                    // If a shot was fired here, show hit or miss
                    bool hit = board.Ships.Any(s => s.Positions.Contains(coord));
                    symbol = hit ? 'X' : 'o';
                }
                Console.Write($" {symbol} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void WriteLine(string text = "") => Console.WriteLine(text);
}