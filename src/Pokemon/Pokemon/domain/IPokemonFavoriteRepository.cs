namespace Pokemon.Pokemon.Domain
{
    public interface IPokemonFavoriteRespository
    {
        int Get(PokemonId pokemonId);

        void Save(PokemonId pokemonId);
    }
}
