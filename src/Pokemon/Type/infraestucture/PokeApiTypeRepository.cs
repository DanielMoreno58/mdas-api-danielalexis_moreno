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
            List<domain.Type> types = HttpAdapter.PokeApiTypeDtoListToTypesList(_pokeApiHttpClient.FindByPokemonNameAsync(pokemonName.Value).Result);
            return types;
        }

        public List<domain.Type> GetTypes()
        {
            return HttpAdapter.PokeApiTypeDtoListToTypesList(_pokeApiHttpClient.GetTypesAsync().Result);
        }        
    }
}
