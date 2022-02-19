using Microsoft.Extensions.DependencyInjection;
using Pokemon.Type.Domain;
using Pokemon.Type.Infrastructure;

namespace Pokemon.Type.Infrastructure;

public static class InfraestructureDependencyInjection
{
    public static IServiceCollection AddTypeInfraestructure(this IServiceCollection services)
    {
        services.AddScoped<ITypeRepository, PokeApiTypeRepository>();

        return services;
    }
}