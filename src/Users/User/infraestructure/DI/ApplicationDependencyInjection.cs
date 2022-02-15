using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Users.User.application;

namespace Users.User.infraestructure.DI;

public static class ApplicationDependencyInjection
{    
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddTransient<CreateUserUseCase>();
        services.AddTransient<AddPokemonFavoriteUseCase>();
        return services;
    }
}