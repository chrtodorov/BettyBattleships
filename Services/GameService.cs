using BettyBattleships.Interfaces;
using BettyBattleships.Models;
using Microsoft.Extensions.Options;

namespace BettyBattleships.Services;

public class GameService : IGameService
{
    private readonly IDisplayService _display;
    private readonly IInputService _input;
    private readonly IShipPlacementService _placement;
    private readonly IShotResolutionService _shotResolver;

    private readonly Board _board;

    public GameService(IDisplayService display,
        IInputService input,
        IShipPlacementService placement,
        IShotResolutionService shotResolver, 
        IOptions<GameOptions> options)
    {
        _display = display;
        _input = input;
        _placement = placement;
        _shotResolver = shotResolver;
        _board = new Board(size: options.Value.BoardSize);
    }

    public void Run()
    {
        _placement.PlaceFleet(_board);

        while (true)
        {
            _display.RenderShotBoard(_board);
            var shot = _input.ReadCoordinate();
            var (result, message) = _shotResolver.ResolveShot(_board, shot);
            _display.WriteLine(message);

            if (_shotResolver.AllShipsSunk(_board))
            {
                _display.RenderShotBoard(_board);
                _display.WriteLine("All ships sunk! You win!\n");
                break;
            }

            _display.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}