using Pokemon.Pokemon.Application;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using Shared.Events.Domain;

namespace Pokemon.Pokemon.Infrastructure
{
    public class PokemonAddFavoriteSuscriber : BackgroundService
    {
        private readonly ILogger<PokemonAddFavoriteSuscriber> _logger;
        private readonly IEventPublisher _eventPublisher;
        private readonly PokemonAddAsFavoriteUseCase _pokemonAddAsFavoriteUseCase;

        public PokemonAddFavoriteSuscriber(
            ILogger<PokemonAddFavoriteSuscriber> logger,
            IEventPublisher eventPublisher,
            PokemonAddAsFavoriteUseCase pokemonAddAsFavoriteUseCase
        )
        {
            _logger = logger;
            _eventPublisher = eventPublisher;
            _pokemonAddAsFavoriteUseCase = pokemonAddAsFavoriteUseCase;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("PokemonAddAsFavoriteSubscriber is running.");
            await _eventPublisher.Consume<PokemonFavoriteSuscribeAddedEvent>(
                Exchange.DomainEvents,
                Queue.CounterFavorite,
                "pokemonfavorite.added",
                message =>
                {
                    Task.Run(() => { DidJob(message); }, stoppingToken);
                }
            );
        }

        private void DidJob(PokemonFavoriteSuscribeAddedEvent message)
        {
            _logger.LogInformation("PokemonAddAsFavoriteSubscriber received a message.");
            _pokemonAddAsFavoriteUseCase.Execute(int.Parse(message.AggregateId));
        }
    }
}