using System;
namespace Pokemon.Type.Domain
{
    public class PokemonApiNotResponseException : Exception
    {
        public PokemonApiNotResponseException()
            : base("Api Not Response")
        { }
    }
}
