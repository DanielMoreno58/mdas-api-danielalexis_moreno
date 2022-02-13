namespace Users.User.domain
{
    public class User
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

        public static User Create(UserId id, UserName userName)
        {
            return new User(id, userName);
        }

        public UserId Id => _userId;
        public UserName UserName => _userName;
        public FavoritesCollection PokemonFavorites => _pokemonFavorites;
    }
}
