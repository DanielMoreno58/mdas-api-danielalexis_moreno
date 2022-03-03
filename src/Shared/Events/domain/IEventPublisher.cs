namespace Shared.Events.Domain
{
    public interface IEventPublisher
    {
        Task Publish<T>(string exchangeName, string queueName, T @event)  where T : DomainEvent;

        Task Consume<T>(string exchangeName, string queueName, string eventKey, Action<T> onEventReceived) where T : DomainEvent;

    }
}