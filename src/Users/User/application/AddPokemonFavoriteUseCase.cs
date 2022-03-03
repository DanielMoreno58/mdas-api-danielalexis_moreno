using Users.User.Domain;
using Shared.Events.Domain;

namespace Users.User.Application
{
    public class AddPokemonFavoriteUseCase
    {
        private readonly UserAddPokemonFavorite _userAddPokemonFavorite;
        private readonly AddPokemonFavoritePublisher _addPokemonFavoritePublisher;

        public AddPokemonFavoriteUseCase(UserAddPokemonFavorite userAddPokemonFavorite, AddPokemonFavoritePublisher addPokemonFavoritePublisher)
        {
            _userAddPokemonFavorite = userAddPokemonFavorite;
            _addPokemonFavoritePublisher = addPokemonFavoritePublisher;
        }

        public void Execute(Guid userIdparam, int pokemonIdparam)
        {
            var userId = new UserId(userIdparam);
            var pokemonId = new PokemonId(pokemonIdparam);
            var pokemonFavorite = PokemonFavorite.Create(pokemonId);

            _userAddPokemonFavorite.Execute(userId, pokemonFavorite);
            _addPokemonFavoritePublisher.Publish(pokemonFavorite.PokemonId.Value);
        }
    }
}
