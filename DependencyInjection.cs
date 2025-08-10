using BettyBattleships.Interfaces;
using BettyBattleships.Models;
using BettyBattleships.Services;
using BettyBattleships.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BettyBattleships;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IDisplayService, DisplayService>();
        services.AddSingleton<IInputService, InputService>();
        services.AddSingleton<IShipPlacementService, ShipPlacementService>();
        services.AddSingleton<IShotResolutionService, ShotResolutionService>();
        services.AddSingleton<IRandomProvider, RandomProvider>();
        services.AddSingleton<IGameService, GameService>();
    }

    public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GameOptions>(configuration.GetSection(nameof(GameOptions)));
    }
}