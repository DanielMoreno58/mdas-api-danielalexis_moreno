using Microsoft.Extensions.DependencyInjection;
using Users.User.Application;

namespace Users.User.Infraestructure;

public static class ApplicationDependencyInjection
{    
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddTransient<CreateUserUseCase>();
        services.AddTransient<AddPokemonFavoriteUseCase>();
        return services;
    }
}