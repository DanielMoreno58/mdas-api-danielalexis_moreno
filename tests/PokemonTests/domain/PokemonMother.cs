using Pokemon.Pokemon.Domain;

namespace PokemonTests.Domain
{
    public class PokemonMother{
        public static Pokemon.Pokemon.Domain.Pokemon Random()
        {
            PokemonId pokemonId = PokemonIdMother.Random();
            PokemonName pokemonName = PokemonNameMother.Random();
            PokemonHeight pokemonHeight = PokemonHeightMother.Random();
            PokemonWeight pokemonWeight = PokemonWeightMother.Random();
            PokemonCounterFavorite pokemonCounterFavorite = PokemonCounterFavoriteMother.Random();

            return Pokemon.Pokemon.Domain.Pokemon.Create(pokemonId, pokemonName, pokemonHeight, pokemonWeight, pokemonCounterFavorite); 
        }
    }
}