using Microsoft.Extensions.DependencyInjection;
using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infraestructure;

public static class InfraestructureDependencyInjection
{
    public static IServiceCollection AddPokemonInfraestructure(this IServiceCollection services)
    {
        services.AddScoped<IPokemonRepository, PokeApiPokemonRepository>();

        return services;
    }
}