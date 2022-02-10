namespace Users.User.domain
{
    public class FavoritesCollection: List<PokemonFavorite> {        
        public void AddPokemonFavorite(PokemonFavorite favorite) {

            GuardAgainstPokemonFavoriteAlreadyExist(favorite);
            
            base.Add(favorite);
        }

        private void GuardAgainstPokemonFavoriteAlreadyExist(PokemonFavorite favorite) {
            if (this.Any(p => p.PokemonId == favorite.PokemonId))
                throw new PokemonFavoriteAlreadyExistException();
        }

        private new void Add(PokemonFavorite favorite)
        {
            this.AddPokemonFavorite(favorite);
        }

    }
}