namespace Shared.Events.Domain
{
    public interface IEventPublisher
    {
        Task Publish<Event>(string exchangeName, string queueName, Event @event);

        Task Consume<Event>(string exchangeName, string queueName, string eventKey, Action<Event> onEventReceived);

    }
}