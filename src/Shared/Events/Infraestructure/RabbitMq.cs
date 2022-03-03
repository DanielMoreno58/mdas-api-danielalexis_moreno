using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Events.Domain;

namespace Shared.Events.Infraestructure
{
    public class RabbitMq : IEventPublisher
    {
        private readonly IModel _channel;

        public RabbitMq(IModel channel)
        {
            _channel = channel;
        }
        
        public async Task Publish<Event>(string exchangeName, string queue, Event @event) => await SendEvent(exchangeName, queue, @event);
        
        public async Task Publish<Event>(string exchangeName, string queue, List<Event> events)
        {
            foreach (var @event in events)
            {
                await SendEvent(exchangeName, queue, @event);
            }
        }
        
        public async Task Consume<Event>(string exchangeName, string queue, string type, Action<Event> onMessage) 
        {
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(queue, true, false, false, null);
            _channel.QueueBind(queue, exchangeName, type, null);
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var json = Encoding.UTF8.GetString(ea.Body.Span);
                var item = JsonSerializer.Deserialize<Event>(json);
                onMessage(item);
                await Task.Yield();
            };
            _channel.BasicConsume(queue, true, consumer);
            await Task.Yield();
        }


        private async Task SendEvent<Event>(string exchangeName, string queue, Event @event)
        {
            await Task.Run(() => {
                _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                _channel.QueueDeclare(queue, true, false, false, null);
                _channel.QueueBind(queue, exchangeName, "@event.Type", null);
                IBasicProperties properties = _channel.CreateBasicProperties();
                //properties.Type = @event.GetType();
                byte[] output = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));
                _channel.BasicPublish(exchangeName, "@event.Type", properties, output);
            });
        }
    }
}
