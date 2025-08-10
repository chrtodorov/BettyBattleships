using BettyBattleships;
using BettyBattleships.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var services = new ServiceCollection();

services.AddConfiguration(configuration);

services.RegisterServices();

using var provider = services.BuildServiceProvider();
var game = provider.GetRequiredService<IGameService>();
game.Run();