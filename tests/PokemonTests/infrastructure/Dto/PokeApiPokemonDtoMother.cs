using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.Pokemon.Infrastructure;

namespace PokemonTests.Infrastructure.Dto
{
    public class PokeApiPokemonDtoMother
    {
        public static PokeApiPokemonDto Random()
        {
            int id = Faker.RandomNumber.Next();
            string name = Faker.Name.First();
            int height = Faker.RandomNumber.Next();
            int weight = Faker.RandomNumber.Next();

            PokeApiPokemonDto pokeApiPokemonDto = new PokeApiPokemonDto(id, name, height, weight);
            
            return pokeApiPokemonDto;
        }
    }
}
