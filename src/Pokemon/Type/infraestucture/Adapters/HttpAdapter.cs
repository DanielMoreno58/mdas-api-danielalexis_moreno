using Pokemon.Type.domain;
using Pokemon.Type.infraestucture.HttpClients.PokeApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Type.infraestucture.Adapters
{
    public static class HttpAdapter
    {
        public static domain.Type PokeApiTypeDtoToType(PokeApiTypeDto pokeApiTypeDto)
        {
            domain.Type type = domain.Type.Create(new TypeName(pokeApiTypeDto.Name));
            return type;
        }
        public static List<domain.Type> PokeApiTypeDtoListToTypesList(List<PokeApiTypeDto> pokeApiTypeDtos)
        {
            List<domain.Type> types = new List<domain.Type>();
            pokeApiTypeDtos.ForEach(pokeApiTypeDto => types.Add(PokeApiTypeDtoToType(pokeApiTypeDto)));
            return types;
        }

        public static PokeApiTypeDto PokeApiTypeWrapDtoToPokeApiTypeDto(PokeApiTypeWrapDto pokeApiTypeWrapDto)
        {
            PokeApiTypeDto pokeApiTypeDto = new PokeApiTypeDto
            {
                Name = pokeApiTypeWrapDto.Type.Name,
                Url = pokeApiTypeWrapDto.Type.Url
            };
            return pokeApiTypeDto;
        }

        public static List<PokeApiTypeDto> PokeApiTypeWrapDtoListToPokeApiTypeDtoList(List<PokeApiTypeWrapDto> pokeApiTypeWrapDtos)
        {
            List<PokeApiTypeDto> types = new List<PokeApiTypeDto>();
            pokeApiTypeWrapDtos.ForEach(pokeApiTypeWrapDto => types.Add(PokeApiTypeWrapDtoToPokeApiTypeDto(pokeApiTypeWrapDto)));
            return types;
        }

    }
}
