using BettyBattleships.Interfaces;
using BettyBattleships.Models;
using BettyBattleships.Utils;
using Microsoft.Extensions.Options;

namespace BettyBattleships.Services;

public class InputService : IInputService
{
    private readonly IDisplayService _display;
    private readonly int _boardSize;
    private readonly IOptions<GameOptions> _options;

    public InputService(IDisplayService display, IOptions<GameOptions> options)
    {
        _display = display;
        _options = options;
        _boardSize = _options.Value.BoardSize;
    }

    public Coordinate ReadCoordinate()
    {
        while (true)
        {
            _display.WriteLine("Enter coordinate (e.g., B7): ");
            var input = Console.ReadLine();
            if (CoordinateParser.TryParse(input, out var coord, _boardSize))
            {
                return coord;
            }
            _display.WriteLine("Invalid coordinate. Use A-J for rows and 1-10 for columns. Try again.\n");
        }
    }
}