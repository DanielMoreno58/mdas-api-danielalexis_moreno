using System;

namespace Pokemon.Type.application
{
    public class GetTypesByPokemonNameQuery
    {
        private string _name;
        
        public GetTypesByPokemonNameQuery(string name)
        {
            _name = name;
        }

        public PokemonName Name()
        {
            return new PokemonName(_name);
        }
    }
}
