using Moq;
using Users.User.domain;
using Xunit;

namespace UsersTest.domain
{
    public class PokemonFavoritesCollectionShould
    {
        [Fact]
        public void Throw_An_Exception_When_PokemonFavorite_Already_Exists()
        {
            //Given
            var pokemonId = PokemonIdMother.Random();
            var pokemonFavorite = PokemonFavoriteMother.Random(pokemonId);
            var pokemonFavoritesCollection =  PokemonFavoritesCollectionMother.Random(pokemonFavorite);

            //When - Then
            Assert.Throws<PokemonFavoriteAlreadyExistException>(() => pokemonFavoritesCollection.AddPokemonFavorite( pokemonFavorite));
        }

        [Fact]
        public void Add_PokemonFavorite()
        {
            //Given
            var pokemonId = PokemonIdMother.Random();
            var pokemonFavorite = PokemonFavoriteMother.Random(pokemonId);
            var pokemonFavoritesCollection = PokemonFavoritesCollectionMother.Random();

            //When
            pokemonFavoritesCollection.AddPokemonFavorite(pokemonFavorite);

            //Then
            Assert.Contains<PokemonFavorite>(pokemonFavorite, pokemonFavoritesCollection);
        }
    }
}
 