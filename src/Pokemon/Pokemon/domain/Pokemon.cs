namespace Pokemon.Pokemon.Domain
{
    public class Pokemon
    {
        private readonly PokemonId _pokemonId;
        private readonly PokemonName _pokemonName;
        private readonly PokemonHeight _pokemonHeight;
        private readonly PokemonWeight _pokemonWeight;
        private readonly PokemonCounterFavorite _pokemonCounterFavorite;

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
    }
}