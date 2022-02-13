using System.Linq;

namespace Users.User.infraestructure.Persistence.Contexts
{
    public partial class UserContext     {

        public UserContext()
        {
            Users = new List<domain.User>();
            Favorites = new List<domain.PokemonFavorite>();
        }

        private IEnumerable<domain.User> Users { get; set; }
        private IEnumerable<domain.PokemonFavorite> Favorites { get; set; }        
        
        public List<TEntity> Set<TEntity>()
        {
            List<TEntity> entities = new List<TEntity>();
            string className = typeof(TEntity).Name;

            switch (className)
            {
                case "User":
                    entities = (List<TEntity>)Users;
                    break;
                case "PokemonFavorite":
                    entities = (List<TEntity>)Favorites;
                    break;
                default:
                    break;
            }
            return entities;
        }
    }
}
