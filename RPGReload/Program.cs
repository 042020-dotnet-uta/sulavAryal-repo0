using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace RPGReload
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                //GamePlay game = serviceProvider.GetService<GamePlay>();

                //game.GetPlayersName();
                //game.RunGame();
                //game.PrintResults();
            }


        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
            .AddTransient<Player>();
        }
    }
}
