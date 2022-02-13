using Microsoft.Extensions.DependencyInjection;
using Users.User.domain;

namespace Users.User.infraestructure.DI;

public static class DomainDependencyInjection
{    
    public static IServiceCollection AddDomains(this IServiceCollection services)
    {

        services.AddTransient<UserCreator>();
        services.AddTransient<UserAddPokemonFavorite>();

        return services;
    }
}