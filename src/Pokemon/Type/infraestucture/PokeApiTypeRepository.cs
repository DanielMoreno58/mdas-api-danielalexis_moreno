using System.Collections.Generic;
using System.Threading.Tasks;
using Pokemon.Type.domain;
using Pokemon.Type.infraestucture.Adapters;
using Pokemon.Type.infraestucture.HttpClients.PokeApi;

namespace Pokemon.Type.infraestucture
{
    public class PokeApiTypeRepository : ITypeRepository
    {
        private PokeApiHttpClient _pokeApiHttpClient;
        public PokeApiTypeRepository(PokeApiHttpClient pokeApiHttpClient)
        {
            _pokeApiHttpClient = pokeApiHttpClient;
        }
        public List<domain.Type> FindByPokemonName(PokemonName pokemonName)
        {
            var pokemon = _pokeApiHttpClient.FindByPokemonNameAsync(pokemonName.Value).Result;

            List<domain.Type> types = HttpAdapter.PokeApiTypeDtoListToTypesList(pokemon);
            return types;
        }
    
    }
}
