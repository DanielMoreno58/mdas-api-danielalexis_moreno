namespace Users.User.domain
{
    public class FavoritesCollection {
        private readonly List<PokemonId> _pokemonFavorites;

        public FavoritesCollection() {
            _pokemonFavorites = new List<PokemonId>();
        }

        public IReadOnlyCollection<PokemonId> PokemonFavorites => _pokemonFavorites;
        
        public void AddPokemonFavorite(PokemonId pokemonId) {
            guardAgainstPokemonFavoriteAlreadyExist(pokemonId);
            _pokemonFavorites.Add(pokemonId);
        }

        private void guardAgainstPokemonFavoriteAlreadyExist(PokemonId pokemonId) {
            if (_pokemonFavorites.Contains(pokemonId)) {
                throw new PokemonFavoriteAlreadyExistException();
            }
        }
    }
}