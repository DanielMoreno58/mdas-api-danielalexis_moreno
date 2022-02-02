using Pokemon.Type.domain;
using Pokemon.Type.infraestucture.HttpClients.PokeApi;
using System.Collections.Generic;

namespace Pokemon.Type.infraestucture.Adapters
{
    internal static class HttpAdapter
    {
        private static domain.Type PokeApiTypeDtoToType(PokeApiTypeDto pokeApiTypeDto)
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

        public static List<PokeApiTypeDto> PokeApiTypesDtoListToPokeApiTypeDtoList(List<PokeApiTypesDto> pokeApiTypeWrapDtos)
        {
            List<PokeApiTypeDto> types = new List<PokeApiTypeDto>();
            pokeApiTypeWrapDtos.ForEach(pokeApiTypeWrapDto => types.Add(PokeApiTypesDtoToPokeApiTypeDto(pokeApiTypeWrapDto)));
            return types;
        }

        private static PokeApiTypeDto PokeApiTypesDtoToPokeApiTypeDto(PokeApiTypesDto pokeApiTypesDto)
        {
            PokeApiTypeDto pokeApiTypeDto = new PokeApiTypeDto
            {
                Name = pokeApiTypesDto.Type.Name,
                Url = pokeApiTypesDto.Type.Url
            };
            return pokeApiTypeDto;
        }
    }
}
