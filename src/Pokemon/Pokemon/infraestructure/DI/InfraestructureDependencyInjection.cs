using Microsoft.Extensions.DependencyInjection;
using Pokemon.Pokemon.Domain;
using Pokemon.Pokemon.Infraestucture;

namespace Pokemon.Pokemon.Infraestructure;

public static class InfraestructureDependencyInjection
{
    public static IServiceCollection AddPokemonInfraestructure(this IServiceCollection services)
    {
        services.AddScoped<IPokemonRepository, PokeApiPokemonRepository>();

        return services;
    }
}