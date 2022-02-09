namespace Users.User.domain
{
    public class UserAddPokemonFavorite
    {
        private readonly IUserRepository _userRepository;

        public UserAddPokemonFavorite(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(User user, PokemonId pokemonId)
        {
            user.PokemonFavorites.AddPokemonFavorite(pokemonId);

            _userRepository.Save(user);
        }
    }
}
