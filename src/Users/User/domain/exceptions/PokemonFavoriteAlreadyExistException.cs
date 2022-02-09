namespace Users.User.domain
{
    public class PokemonFavoriteAlreadyExistException : Exception
    {
        public PokemonFavoriteAlreadyExistException() 
            : base("Pokemon already added to favorites")
        {
        }
    }
}
