using System;
namespace Pokemon.Type.domain
{
    public class PokemonApiNotResponseException : Exception
    {
        public PokemonApiNotResponseException()
            : base("Api Not Response")
        { }
    }
}
