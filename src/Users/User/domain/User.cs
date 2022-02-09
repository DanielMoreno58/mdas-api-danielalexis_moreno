namespace Users.User.domain
{
    public sealed class User
    {
        private readonly UserId _userId;
        private readonly UserName _userName;
        private readonly FavoritesCollection _pokemonFavorites;

        private User(UserId userId, UserName userName)
        {
            _userId = userId;
            _userName = userName;
            _pokemonFavorites = new FavoritesCollection();
        }

        public static User Create(UserId userId, UserName userName)
        {
            return new User(userId, userName);
        }

        public UserId UserId => _userId;
        public UserName UserName => _userName;
        public FavoritesCollection PokemonFavorites => _pokemonFavorites;
    }
}
