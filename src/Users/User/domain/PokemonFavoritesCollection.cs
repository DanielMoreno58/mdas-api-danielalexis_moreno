using System.Collections.Generic;
using System.Linq;

namespace Users.User.Domain
{
    public class PokemonFavoritesCollection: List<PokemonFavorite> {        
        public void Add(PokemonFavorite favorite) {

            GuardAgainstPokemonFavoriteAlreadyExist(favorite);
            
            base.Add(favorite);
        }

        private void GuardAgainstPokemonFavoriteAlreadyExist(PokemonFavorite favorite) {
            if (this.Any(p => p.PokemonId == favorite.PokemonId))
                throw new PokemonFavoriteAlreadyExistException();
        }

    }
}