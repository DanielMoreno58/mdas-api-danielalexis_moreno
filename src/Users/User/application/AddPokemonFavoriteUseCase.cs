using Users.User.domain;

namespace Users.User.application
{
    internal class AddPokemonFavoriteUseCase
    {
        private readonly UserFindById _userFindById;
        private readonly UserAddPokemonFavorite _userAddPokemonFavorite;

        public AddPokemonFavoriteUseCase(UserFindById userFindById, UserAddPokemonFavorite userAddPokemonFavorite)
        {
            _userFindById = userFindById;
            _userAddPokemonFavorite = userAddPokemonFavorite;
        }

        public void Execute(UserId userId, PokemonId pokemonId)
        {
            var user = _userFindById.Execute(userId);

            _userAddPokemonFavorite.Execute(user,pokemonId);
        }
    }
}
