using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.User.domain;

namespace Users.User.infraestructure.Persistence.Contexts.Configurations;
public partial class FavoriteConfiguration : IEntityTypeConfiguration<domain.PokemonFavorite>
{
    public void Configure(EntityTypeBuilder<domain.PokemonFavorite> entity)
    {
        entity.ToTable("Favorite", "ePokemon");

        //entity.Property(e => e.Id)
        //    .ValueGeneratedNever()
        //    .HasConversion(v => v.Value, v => new FavoriteId(v))
        //    .HasDefaultValueSql("newid()");

        //entity.Property(e => e.PokemonId)
        //    .HasConversion(v => v.Value, v => new PokemonId(v));

        //entity.Property(e => e.UserId)
        //    .HasConversion(v => v.Value, v => new UserId(v));

        //entity.HasOne(e=>e.User)            
        //    .WithMany(p => p.PokemonFavorites)
        //    .HasForeignKey(d => d.UserId)
        //    .HasConstraintName("FK_PokemonFavoritesUser");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<domain.PokemonFavorite> entity);
}

