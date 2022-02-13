using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Users.User.domain;
using Users.User.infraestructure.Persistence.Contexts;
using Users.User.infraestructure.Persistence.Repositories;

namespace Users.User.infraestructure.DI;

public static class PersistenceDependencyInjection
{    
    public static IServiceCollection AddPersistences(this IServiceCollection services)
    {
                
        services.AddScoped<IUserRepository, InMemoryUserRepository>();
        services.AddSingleton<UserContext>();

        return services;
    }
}