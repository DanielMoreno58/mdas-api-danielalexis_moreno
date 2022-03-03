using System.Collections.Generic;
using Shared.Events.Domain;

namespace Users.User.Domain
{
    public class User
    {
        private readonly UserId _userId;
        private readonly UserName _userName;
        private readonly PokemonFavoritesCollection _pokemonFavorites;

        private List<DomainEvent> _events = new List<DomainEvent>();
        private User(UserId userId, UserName userName)
        {
            _userId = userId;
            _userName = userName;
            _pokemonFavorites = new PokemonFavoritesCollection();
        }

        public static User Create(UserId id, UserName userName)
        {
            return new User(id, userName);
        }

        public UserId Id => _userId;
        public UserName UserName => _userName;
        public PokemonFavoritesCollection PokemonFavorites => _pokemonFavorites;

        private void AddDomainEvent(DomainEvent @event) => _events.Add(@event);
        public void AddPokemonFavorite(PokemonFavorite favorite){
            _pokemonFavorites.Add(favorite);
            AddDomainEvent(new PokemonFavoriteAddedEvent(favorite.PokemonId.Value.ToString()));
        }

        public List<DomainEvent> GetAllDomainEvents()
        {
            var events = _events;
            _events = new List<DomainEvent>();
            return events;
        }
    }
}
