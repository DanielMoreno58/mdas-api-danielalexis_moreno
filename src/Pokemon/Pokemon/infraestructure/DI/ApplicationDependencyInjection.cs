using Microsoft.Extensions.DependencyInjection;
using Pokemon.Pokemon.Application;

namespace Pokemon.Pokemon.Infraestructure;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddPokemonApplication(this IServiceCollection services)
    {
        services.AddTransient<GetPokemonByPokemonIdUseCase>();
        return services;
    }
}