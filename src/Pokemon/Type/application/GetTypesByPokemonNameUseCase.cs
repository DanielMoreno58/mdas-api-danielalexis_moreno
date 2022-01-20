using System;
using System.Collections.Generic;
using Pokemon.Type.domain;

namespace Pokemon.Type.application
{
    public class GetTypesByPokemonNameUseCase
    {
        private readonly FindByPokemonName _findByPokemonName;

        public GetTypesByPokemonNameUseCase(FindByPokemonName findByPokemonName)
        {
            _findByPokemonName = findByPokemonName;
        }

        public List<Pokemon.Type.domain.Type> Execute(GetTypesByPokemonNameQuery getTypesByPokemonNameQuery)
        {
            return _findByPokemonName.Execute(getTypesByPokemonNameQuery.Name());
        }
    }
}
