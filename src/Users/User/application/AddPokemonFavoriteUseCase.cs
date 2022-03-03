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

        private RabbitMq rabbitMq;

        public AddPokemonFavoriteUseCase(UserAddPokemonFavorite userAddPokemonFavorite, AddPokemonFavoritePublisher addPokemonFavoritePublisher, 
        UserFinder userFinder)
        {
            _userAddPokemonFavorite = userAddPokemonFavorite;
            _addPokemonFavoritePublisher = addPokemonFavoritePublisher;
            _userFinder = userFinder;
        }

        public void Execute(Guid userIdparam, int pokemonIdparam)
        {
            var user = _userFinder.Execute(new UserId(userIdparam));
            var userId = new UserId(userIdparam);
            var pokemonId = new PokemonId(pokemonIdparam);
            var pokemonFavorite = PokemonFavorite.Create(pokemonId);

            _userAddPokemonFavorite.Execute(userId, pokemonFavorite);
            Console.WriteLine("llego aqui");
            rabbitMq.Publish(Exchange.DomainEvents, Queue.CounterFavorite, user.GetAllDomainEvents()).Wait();

        }
    }
}
