namespace Users.User.domain
{
    public class FavoritesCollection: List<Favorite> {        
        public void AddPokemonFavorite(Favorite favorite) {
            guardAgainstPokemonFavoriteAlreadyExist(favorite);
            base.Add(favorite);
        }

        private void guardAgainstPokemonFavoriteAlreadyExist(Favorite favorite) {
            if (this.Where(p => p.PokemonId == favorite.PokemonId && p.UserId == favorite.UserId).Any())
            {
                throw new PokemonFavoriteAlreadyExistException();
            }
        }

        public new void Add(Favorite favorite)
        {
            this.AddPokemonFavorite(favorite);
        }

        public new void AddRange(List<Favorite> favorites)
        {
            base.AddRange(favorites);
        }
    }
}