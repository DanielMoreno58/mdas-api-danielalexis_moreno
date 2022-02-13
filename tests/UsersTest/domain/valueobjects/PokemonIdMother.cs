using Users.User.domain;
using Users.User.infraestructure;

namespace UsersTest.domain
{
    public class PokemonIdMother
    {
        public static PokemonId Random()
        {
            return new PokemonId(GuidCreator.Execute());
        }
    }

}
