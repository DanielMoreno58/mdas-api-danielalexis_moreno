namespace Users.User.Domain;
public class PokemonFavoriteAddedEvent
{
    private String _action;
    private PokemonId _pokemonId;

    public PokemonFavoriteAddedEvent(String action, PokemonId pokemonId)
    {
        _action = action;
        _pokemonId = pokemonId;
    }

}
