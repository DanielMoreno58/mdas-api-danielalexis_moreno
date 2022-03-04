using Microsoft.Extensions.DependencyInjection;

namespace Shared.Events.Infraestructure;
public static class DependencyInjection
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddSingleton(sp => RabbitHutch.CreateBus("amqp://netcoders:netcoders@rabbitmq:5672/netcoders"));
        return services;
    }
}
