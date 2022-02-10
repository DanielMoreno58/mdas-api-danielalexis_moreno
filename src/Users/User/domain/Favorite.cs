namespace Users.User.domain;
public class Favorite
{
    private readonly FavoriteId _favoriteId;
    private readonly PokemonId _pokemonId;
    private readonly UserId _userId;

    private Favorite(FavoriteId id, PokemonId pokemonId, UserId userId)
    {
        _favoriteId = id;
        _pokemonId = pokemonId;
        _userId = userId;
    }

    private Favorite(FavoriteId id, PokemonId pokemonId, User user)
        :this(id, pokemonId,user.Id)
    {
        User = user;
    }

    public static Favorite Create(FavoriteId pokemonFavoriteId, PokemonId pokemonId, UserId userId)
    {
        return new Favorite(pokemonFavoriteId, pokemonId, userId);
    }

    public FavoriteId Id => _favoriteId;
    public PokemonId PokemonId => _pokemonId;
    public UserId UserId => _userId;

    public virtual User User { get; set; }
}
