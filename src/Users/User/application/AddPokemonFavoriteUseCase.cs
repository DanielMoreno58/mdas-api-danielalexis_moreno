using Users.User.domain;

namespace Users.User.application
{
    internal class AddPokemonFavoriteUseCase
    {
        private readonly UserFindById _userFindById;

        public AddPokemonFavoriteUseCase(UserFindById userFindById)
        {
            _userFindById = userFindById;
        }

        public void Execute(UserId userId, PokemonId pokemonId)
        {
            var user = _userFindById.Execute(userId);
            user.PokemonFavorites.AddPokemonFavorite(pokemonId);
        }
    }
}
