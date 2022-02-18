using Microsoft.Extensions.DependencyInjection;
using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infraestructure;

public static class DomainDependencyInjection
{
    public static IServiceCollection AddDomains(this IServiceCollection services)
    {
        services.AddTransient<PokemonFinder>();

        return services;
    }
}