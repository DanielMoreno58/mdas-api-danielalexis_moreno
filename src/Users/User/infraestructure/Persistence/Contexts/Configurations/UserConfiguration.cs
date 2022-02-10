using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.User.domain;

namespace Users.User.infraestructure.Persistence.Contexts.Configurations;
public partial class UserConfiguration : IEntityTypeConfiguration<domain.User>
{
    public void Configure(EntityTypeBuilder<domain.User> entity)
    {
        entity.ToTable("User", "ePokemon");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(v => v.Value, v => new UserId(v))
            .HasDefaultValueSql("newid()");

        entity.Property(e => e.UserName)
            .HasConversion(v => v.Value, v => new UserName(v))
            .IsRequired()
            .HasMaxLength(250)
            .IsUnicode(false);

        entity.HasMany(e=>e.PokemonFavorites)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_PokemonFavoritesUser");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<domain.User> entity);
}

