using Pokemon.Type.Infraestucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeTests.Infrastructure.HttpClients.PokeApi
{
    public class PokeApiTypesDtoMother
    {
        public static PokeApiTypesDto Random()
        {
            PokeApiTypeDto type = PokeApiTypeDtoMother.Random();
            PokeApiTypesDto pokeApiTypesDto = new PokeApiTypesDto(type);

            return pokeApiTypesDto;
        }
    }
}
