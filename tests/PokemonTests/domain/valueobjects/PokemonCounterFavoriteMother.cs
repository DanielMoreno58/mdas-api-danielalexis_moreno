using Pokemon.Pokemon.Domain;

namespace PokemonTests.Domain
{
    public class PokemonCounterFavoriteMother
    {
        public static PokemonCounterFavorite Random()
        {
            return new PokemonCounterFavorite(Faker.RandomNumber.Next(1, 100));
        }
    }
}