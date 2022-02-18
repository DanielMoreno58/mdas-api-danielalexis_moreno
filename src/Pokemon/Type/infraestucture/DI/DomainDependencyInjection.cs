using Microsoft.Extensions.DependencyInjection;
using Pokemon.Type.Domain;

namespace Pokemon.Type.Infraestucture;

public static class DomainDependencyInjection
{
    public static IServiceCollection AddTypeDomain(this IServiceCollection services)
    {
        services.AddTransient<FindByPokemonName>();

        return services;
    }
}