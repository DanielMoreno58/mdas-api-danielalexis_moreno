namespace Pokemon.Pokemon.Domain
{
    public class Pokemon
    {
        private PokemonId _pokemonId;
        private PokemonName _pokemonName;
        private PokemonHeight _pokemonHeight;
        private PokemonWeight _pokemonWeight;
        private PokemonCounterFavorite _pokemonCounterFavorite;

        private Pokemon(PokemonId pokemonId, PokemonName pokemonName, PokemonHeight pokemonHeight, PokemonWeight pokemonWeight, PokemonCounterFavorite pokemonCounterFavorite)
        {
            _pokemonId = pokemonId;
            _pokemonName = pokemonName;
            _pokemonHeight = pokemonHeight;
            _pokemonWeight = pokemonWeight;
            _pokemonCounterFavorite = pokemonCounterFavorite;
        }

        public static Pokemon Create(PokemonId pokemonId, PokemonName pokemonName, PokemonHeight pokemonHeight, PokemonWeight pokemonWeight, PokemonCounterFavorite pokemonCounterFavorite)
        {
            return new Pokemon(pokemonId, pokemonName, pokemonHeight, pokemonWeight, pokemonCounterFavorite);
        }

        public PokemonId PokemonId => _pokemonId;
        public PokemonName PokemonName => _pokemonName;
        public PokemonHeight PokemonHeight => _pokemonHeight;
        public PokemonWeight PokemonWeight => _pokemonWeight;
        public PokemonCounterFavorite PokemonCounterFavorite => _pokemonCounterFavorite;

        public void IncrementFavoriteCounter() => _pokemonCounterFavorite = new PokemonCounterFavorite(_pokemonCounterFavorite.Value + 1);
    }
}