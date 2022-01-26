using Pokemon.Type.infraestucture.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Type.infraestucture.HttpClients.PokeApi
{
    public class PokeApiHttpClient
    {
        private HttpClient _typeClient;
        private HttpClient _pokemonClient;
        private string pokemonUrl = "https://pokeapi.co/api/v2/pokemon/";
        private string typeUrl = "https://pokeapi.co/api/v2/type/";
        public PokeApiHttpClient(HttpClient typeClient,HttpClient pokemoClient)
        {
            InitializeClient(typeClient,pokemoClient);
        }
        public async Task<List<PokeApiTypeDto>> GetTypesAsync()
        {
            return await _typeClient.GetFromJsonAsync<List<PokeApiTypeDto>>("");
        }
        public async Task<PokeApiTypeDto> GetTypeByNameAsync(string typeName)
        {
            string url = $"{typeName}";
            return await _typeClient.GetFromJsonAsync<PokeApiTypeDto>(url);
        }
        public async Task<List<PokeApiTypeDto>> FindByPokemonNameAsync(string pokemonName)
        {
            string url = $"{pokemonName}";
            PokeApiDto pokemon = await _pokemonClient.GetFromJsonAsync<PokeApiDto>(url);
            List <PokeApiTypeDto> types = HttpAdapter.PokeApiTypeWrapDtoListToPokeApiTypeDtoList(pokemon.Types);

            return types;            
        }

        private void InitializeClient(HttpClient typeClient, HttpClient pokemoClient)
        {
            typeClient.BaseAddress = new Uri(typeUrl);
            _typeClient = typeClient;

            pokemoClient.BaseAddress = new Uri(pokemonUrl);
            _pokemonClient = pokemoClient;
        }
    }
}
