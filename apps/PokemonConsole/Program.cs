using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pokemon.Type.application;
using Pokemon.Type.domain;
using Pokemon.Type.infraestucture;
using Pokemon.Type.infraestucture.HttpClients.PokeApi;

namespace PokemonConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging((logging) =>
                {
                    logging.ClearProviders();
                })
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((_, services) => {
                    services.AddTransient<ITypeRepository, PokeApiTypeRepository>();
                    services.AddTransient<GetTypesByPokemonNameUseCase>();
                    services.AddTransient<FindByPokemonName>();
                    services.AddHttpClient<PokeApiHttpClient>();
                    services.AddTransient<ConsoleApp>();
                })
                .Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    ConsoleApp consoleApp = services.GetRequiredService<ConsoleApp>();
                    await consoleApp.RunAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured");
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
