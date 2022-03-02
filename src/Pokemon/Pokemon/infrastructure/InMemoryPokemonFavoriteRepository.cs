using Pokemon.Pokemon.Domain;

namespace Pokemon.Pokemon.Infrastructure
{

    public class InMemoryPokemonFavoriteRepository : IPokemonFavoriteRespository
    {

        public PokemonId _pokemonId;

        public InMemoryPokemonFavoriteRepository(PokemonId pokemonId){
            _pokemonId = pokemonId;
        }

        public int Get(PokemonId pokemonId){
            return 0;
        }

        public void Save(PokemonId pokemonId){
            // Add 
        }
        
    }
}