namespace Pokemon.Pokemon.Domain
{
    public class Pokemon
    {
        private readonly PokemonId _pokemonId;
        private readonly PokemonName _pokemonName;
        private readonly PokemonHeight _pokemonHeight;
        private readonly PokemonWeight _pokemonWeight;
        private readonly CounterPokemonFavorite _counterPokemonFavorite;

        private Pokemon(PokemonId pokemonId, PokemonName pokemonName, PokemonHeight pokemonHeight, PokemonWeight pokemonWeight, CounterPokemonFavorite counterPokemonFavorite)
        {
            _pokemonId = pokemonId;
            _pokemonName = pokemonName;
            _pokemonHeight = pokemonHeight;
            _pokemonWeight = pokemonWeight;
            _counterPokemonFavorite = counterPokemonFavorite;
        }

        public static Pokemon Create(PokemonId pokemonId, PokemonName pokemonName, PokemonHeight pokemonHeight, PokemonWeight pokemonWeight, CounterPokemonFavorite counterPokemonFavorite)
        {
            return new Pokemon(pokemonId, pokemonName, pokemonHeight, pokemonWeight, counterPokemonFavorite);
        }

        public PokemonId PokemonId => _pokemonId;
        public PokemonName PokemonName => _pokemonName;
        public PokemonHeight PokemonHeight => _pokemonHeight;
        public PokemonWeight PokemonWeight => _pokemonWeight;
        public CounterPokemonFavorite CounterPokemonFavorite => _counterPokemonFavorite;
    }
}