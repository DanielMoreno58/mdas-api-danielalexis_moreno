using System;
using System.Collections.Generic;

namespace Pokemon.Type.domain
{
    public class ITypeRepository
    {
        List<Type> FindByPokemonName(PokemonName pokemonName);
    }
}
