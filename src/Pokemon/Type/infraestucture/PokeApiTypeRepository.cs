using System;
using System.Collections.Generic;
using Pokemon.Type.domain;
using Pokemon.Type.infraestucture.HttpClients.PokeApi;

namespace Pokemon.Type.infraestucture
{
    public class PokeApiRepository : ITypeRepository
    {
        private PokeApiHttpClient _pokeApiHttpClient;
        public PokeApiRepository(PokeApiHttpClient pokeApiHttpClient)
        {
            _pokeApiHttpClient = pokeApiHttpClient;
        }
        public List<domain.Type> FindByPokemonName(PokemonName pokemonName)
        {
            List<domain.Type> types = new List<domain.Type>
            {
                domain.Type.Create(new TypeName("pikachu")),
                domain.Type.Create(new TypeName("charmander")),
                domain.Type.Create(new TypeName("bulbasaur"))
            };

            return types;
        }
    }
}
