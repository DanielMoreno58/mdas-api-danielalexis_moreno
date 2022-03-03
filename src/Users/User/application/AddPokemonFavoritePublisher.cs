using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Users.User.Application
{
    public class AddPokemonFavoritePublisher
    {
        public void Publish(int PokemonId)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "netcoders";
            factory.Password = "netcoders";
            factory.VirtualHost = "netcoders";
            factory.HostName = "localhost";
            factory.Port = 5672;
            IConnection conn = factory.CreateConnection();
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(PokemonId.ToString()));
                channel.ExchangeDeclare("pokemon_favorite", ExchangeType.Direct);
                channel.QueueDeclare(queue: "counter_pokemon_favorite",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                channel.QueueBind("counter_pokemon_favorite", "pokemon_favorite", "", null);
                /*IBasicProperties properties = channel.CreateBasicProperties();
                properties.Type = "";
                byte[] output = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(""));*/
                channel.BasicPublish(exchange: "pokemon_favorite_event",
                                     routingKey: "counter_pokemon_favorite",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}