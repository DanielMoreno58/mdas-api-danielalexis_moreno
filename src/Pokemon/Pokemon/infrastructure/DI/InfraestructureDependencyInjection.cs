using Microsoft.Extensions.DependencyInjection;
using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infrastructure;

public static class infrastructureDependencyInjection
{
    public static IServiceCollection AddPokemoninfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IPokemonRepository, PokeApiPokemonRepository>();
        services.AddHostedService<PokemonAddFavoriteSuscriber>();

        return services;
    }
}