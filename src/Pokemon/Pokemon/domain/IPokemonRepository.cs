namespace Pokemon.Pokemon.Domain
{
    public interface IPokemonRepository
    {
        Pokemon Find(PokemonId pokemonId);
    }
}
