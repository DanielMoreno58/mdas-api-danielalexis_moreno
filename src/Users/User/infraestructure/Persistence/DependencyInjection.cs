using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Users.User.domain;
using Users.User.infraestructure.Persistence.Contexts;
using Users.User.infraestructure.Persistence.Repositories;

namespace Users.User.infraestructure.Persistence;

public static class DependencyInjection
{
    public class PersistenceInMemoryOptions
    {
        public string DatabaseName { get; set; }
    }
    public static IServiceCollection AddPersistenceInMemory(this IServiceCollection services, Action<PersistenceInMemoryOptions> configureOptions)
    {
        var options = new PersistenceInMemoryOptions();
        configureOptions(options);
                
        services.AddScoped<IUserRepository, EFUserRepository>();
        
        services.AddDbContext<UserContext>(opt =>
        {
            opt.UseInMemoryDatabase(options.DatabaseName);
        });
        return services;
    }

    private class SeederMiddleware
    {
        private readonly RequestDelegate _next;

        public SeederMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }
    }
}