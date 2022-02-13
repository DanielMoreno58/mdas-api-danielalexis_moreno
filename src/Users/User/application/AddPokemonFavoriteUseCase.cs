using Users.User.domain;

namespace Users.User.application
{
    public class AddPokemonFavoriteUseCase
    {
        private readonly UserAddPokemonFavorite _userAddPokemonFavorite;

        public AddPokemonFavoriteUseCase(UserAddPokemonFavorite userAddPokemonFavorite)
        {
            _userAddPokemonFavorite = userAddPokemonFavorite;
        }

        public void Execute(Guid userIdparam, string pokemonIdparam)
        {
            var userId = new UserId(userIdparam);
            var pokemonId = new PokemonId(pokemonIdparam);
            var pokemonFavorite = PokemonFavorite.Create(pokemonId);

            _userAddPokemonFavorite.Execute(userId, pokemonFavorite);
        }
    }
}
