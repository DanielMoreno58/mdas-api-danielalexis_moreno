﻿using System;
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

        public List<Type> GetTypesByPokemonNameUseCase(GetTypesByPokemonNameQuery getTypesByPokemonNameQuery)
        {
            return _findByPokemonName.Execute(getTypesByPokemonNameQuery.Name);
        }
    }
}
