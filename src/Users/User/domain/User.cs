namespace Users.User.domain
{
    public sealed class User
    {
        private readonly UserId _userId;
        private readonly UserName _userName;
        private readonly List<PokemonId> _pokemonFavorites;

        private User(UserId userId, UserName userName)
        {
            _userId = userId;
            _userName = userName;
            _pokemonFavorites = new List<PokemonId>();
        }

        public static User Create(UserId userId, UserName userName)
        {
            return new User(userId, userName);
        }

        public UserId UserId => _userId;
        public UserName UserName => _userName;
        public IReadOnlyCollection<PokemonId> PokemonFavorites => _pokemonFavorites;
        public void AddPokemonFavorite(PokemonId pokemonId)
        {
            if (_pokemonFavorites.Contains(pokemonId)) {
                throw new PokemonFavoriteAlreadyExistException();
            }
            _pokemonFavorites.Add(pokemonId);
        }
    }
}
