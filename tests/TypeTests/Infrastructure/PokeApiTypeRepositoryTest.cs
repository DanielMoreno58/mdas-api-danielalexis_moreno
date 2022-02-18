using Pokemon.Type.Domain;
using Pokemon.Type.Infraestucture;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TypeTests.Infrastructure
{
    public class PokeApiTypeRepositoryTest
    {
        [Fact]
        public void Should_Find_A_Type_By_PokemonName()
        {
            /*
         public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<PokeApiTypesDto> Types { get; set; }
             */

            //Given
            string pokemonUrl = "https://pokeapi.co/api/v2/pokemon/";
            var mockHttp = new MockHttpMessageHandler();
            var res = @"
                {
                    'id': 25,
                    'name': 'pikachu',
                    'url': ''
                    'types': [
                        {
                            'slot': 1,
                            'type': {
                                'name': 'electric',
                                'url': 'https://pokeapi.co/api/v2/type/13'
                            }
                        }
                    ],
                }
            ";
            mockHttp.When($"{pokemonUrl}*").Respond("application/json", res);
            var httpClient = new HttpClient(mockHttp);
            var pokeApiHttpClient = new PokeApiHttpClient(httpClient);
            var pokeApiTypeRepository = new PokeApiTypeRepository(pokeApiHttpClient);
            //When
            var types = pokeApiTypeRepository.FindByPokemonName(new PokemonName("pikachu"));
            //Then
            Assert.Equal("electric",types.First().Name.Value);
        }
    }
}
