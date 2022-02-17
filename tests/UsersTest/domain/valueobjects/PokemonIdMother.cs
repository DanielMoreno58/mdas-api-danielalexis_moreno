using Users.User.Domain;
using Users.User.Infraestructure;

namespace UsersTest.Domain
{
    public class PokemonIdMother
    {
        public static PokemonId Random()
        {
            return new PokemonId(GuidCreator.Execute());
        }
    }

}
