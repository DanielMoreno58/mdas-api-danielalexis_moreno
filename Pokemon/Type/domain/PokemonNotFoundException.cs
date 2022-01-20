using System;
namespace Pokemon.Type.domain
{
    public class PokemonNotFoundException : Exception
    {
        public PokemonNotFoundException()
            : base("Pokemon not found")
        { }
    }
}
