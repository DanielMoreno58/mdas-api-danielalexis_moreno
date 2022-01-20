using System;
namespace Pokemon.Type.domain
{
    public class ITypeRepository
    {
        public ITypeRepository()
        {
            List<Type> FindByPokemonName(PokemonName pokemonName);
        }
    }
}
