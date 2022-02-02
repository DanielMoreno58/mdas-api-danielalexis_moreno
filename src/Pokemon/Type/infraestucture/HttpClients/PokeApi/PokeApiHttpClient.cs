using Pokemon.Type.infraestucture.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Pokemon.Type.domain;

namespace Pokemon.Type.infraestucture.HttpClients.PokeApi
{
    public class PokeApiHttpClient
    {
        private HttpClient _pokemonClient;
        private string pokemonUrl = "https://pokeapi.co/api/v2/pokemon/";
        private string typeUrl = "https://pokeapi.co/api/v2/type/";
   
        public PokeApiHttpClient(HttpClient typeClient, HttpClient pokemoClient)
        {
            InitializeClient(typeClient, pokemoClient);
        }

        public async Task<List<PokeApiTypeDto>> FindByPokemonNameAsync(string pokemonName)
        {
            string url = $"{pokemonName}";
            try
            {
                PokeApiPokemonDto pokemon = await _pokemonClient.GetFromJsonAsync<PokeApiPokemonDto>(url);

                List<PokeApiTypeDto> types = HttpAdapter.PokeApiTypesDtoListToPokeApiTypeDtoList(pokemon.Types);
                return types;
            }
            catch (HttpRequestException e)
            {
                switch (e.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new PokemonNotFoundException();
                    default:
                        throw new PokemonApiNotResponseException();
                }
            }

        }

        private void InitializeClient(HttpClient typeClient, HttpClient pokemoClient)
        {
            typeClient.BaseAddress = new Uri(typeUrl);

            pokemoClient.BaseAddress = new Uri(pokemonUrl);
            _pokemonClient = pokemoClient;
        }
    }
}
