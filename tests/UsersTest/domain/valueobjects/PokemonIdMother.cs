using Users.User.Domain;
using Users.User.Infrastructure;

namespace UsersTest.Domain
{
    public class PokemonIdMother
    {
        public static PokemonId Random()
        {
            return new PokemonId(Faker.RandomNumber.Next(0, 100));
        }
    }

}
