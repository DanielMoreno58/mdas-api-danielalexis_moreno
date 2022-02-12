using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.User.domain;

namespace Users.User.infraestructure.Persistence.Contexts.Configurations;
public partial class FavoriteConfiguration : IEntityTypeConfiguration<PokemonFavorite>
{
    public void Configure(EntityTypeBuilder<PokemonFavorite> entity)
    {
        entity.ToTable("Favorite", "ePokemon");

        entity.Property(e => e.PokemonId)
            .ValueGeneratedNever()
            .HasConversion(v => v.Value, v => new PokemonId(v))
            .HasDefaultValueSql("newid()");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<PokemonFavorite> entity);
}

