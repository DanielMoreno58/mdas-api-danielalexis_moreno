using Microsoft.Extensions.DependencyInjection;
using Users.User.Application;
using Shared.Events.Infraestructure;

namespace Users.User.Infrastructure;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddTransient<CreateUserUseCase>();
        services.AddTransient<AddPokemonFavoriteUseCase>();
        services.AddTransient<AddPokemonFavoritePublisher>();
        services.AddTransient<RabbitMq>();
        return services;
    }
}