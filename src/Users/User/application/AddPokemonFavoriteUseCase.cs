using Users.User.Domain;
using Shared.Events.Domain;
using Shared.Events.Infraestructure;
using System;

namespace Users.User.Application
{
    public class AddPokemonFavoriteUseCase
    {
        private readonly UserAddPokemonFavorite _userAddPokemonFavorite;
        private readonly AddPokemonFavoritePublisher _addPokemonFavoritePublisher;

        public readonly UserFinder _userFinder;

        private RabbitMq _rabbitMq;

        public AddPokemonFavoriteUseCase(UserAddPokemonFavorite userAddPokemonFavorite, AddPokemonFavoritePublisher addPokemonFavoritePublisher, 
        UserFinder userFinder, RabbitMq rabbitMq)
        {
            _userAddPokemonFavorite = userAddPokemonFavorite;
            _addPokemonFavoritePublisher = addPokemonFavoritePublisher;
            _userFinder = userFinder;
            _rabbitMq = rabbitMq;
        }

        public void Execute(Guid userIdparam, int pokemonIdparam)
        {
            var user = _userFinder.Execute(new UserId(userIdparam));
            var userId = new UserId(userIdparam);
            var pokemonId = new PokemonId(pokemonIdparam);
            var pokemonFavorite = PokemonFavorite.Create(pokemonId);

            _userAddPokemonFavorite.Execute(userId, pokemonFavorite);
            _rabbitMq.Publish(Exchange.DomainEvents, Queue.CounterFavorite, user.GetAllDomainEvents()).Wait();

        }
    }
}
