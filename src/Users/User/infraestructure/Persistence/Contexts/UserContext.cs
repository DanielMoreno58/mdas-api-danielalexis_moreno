using Microsoft.EntityFrameworkCore;

namespace Users.User.infraestructure.Persistence.Contexts
{
    public partial class UserContext : DbContext
    {
        public UserContext()
        {
        }
        public UserContext(DbContextOptions<UserContext> options)
           : base(options)
        {
        }

        public virtual DbSet<domain.User> Users { get; set; }
        public virtual DbSet<domain.Favorite> Favorites { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.FavoriteConfiguration());
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
