using Moq;
using Users.User.domain;

namespace UsersTest.domain
{

    public class PokemonFavoriteMother 
    {
        public static PokemonFavorite Random()
        {
            return PokemonFavorite.Create(It.IsAny<PokemonId>()); 
        }

        public static PokemonFavorite Random(PokemonId pokemonId)
        {
            return PokemonFavorite.Create(pokemonId);
        }
    }

}