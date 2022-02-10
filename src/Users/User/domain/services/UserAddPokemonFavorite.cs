namespace Users.User.domain
{
    public class UserAddPokemonFavorite
    {
        private readonly IUserRepository _userRepository;

        public UserAddPokemonFavorite(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(User user, PokemonFavorite pokemonFavorite)
        {
            user.PokemonFavorites.AddPokemonFavorite(pokemonFavorite);

            _userRepository.Save(user);
        }
    }
}
