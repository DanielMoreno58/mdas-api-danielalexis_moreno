using System;
using System.Collections.Generic;

namespace Pokemon.Type.domain
{
    public interface ITypeRepository
    {
        public List<Type> FindByPokemonName(PokemonName pokemonName);
    }
}
