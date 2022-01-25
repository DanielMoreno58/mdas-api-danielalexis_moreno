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
        public HttpClient _client { get; }
        public PokeApiHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
            _client = client;
        }
        public async Task<List<PokeApiDto>> GetPokemons()
        {
            return await _client.GetFromJsonAsync<List<PokeApiDto>>("/");
        }
    }
}
