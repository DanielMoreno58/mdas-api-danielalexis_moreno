using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Type.domain
{
    public interface ITypeRepository
    {
        public List<Type> FindByPokemonName(PokemonName pokemonName);
    }
} 
