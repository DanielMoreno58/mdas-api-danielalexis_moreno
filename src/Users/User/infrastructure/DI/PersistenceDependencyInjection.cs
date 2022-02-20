using Microsoft.Extensions.DependencyInjection;
using Users.User.Domain;

namespace Users.User.Infraestructure;

public static class PersistenceDependencyInjection
{    
    public static IServiceCollection AddPersistences(this IServiceCollection services)
    {
                
        services.AddScoped<IUserRepository, InMemoryUserRepository>();
        services.AddSingleton<UserContext>();

        return services;
    }
}