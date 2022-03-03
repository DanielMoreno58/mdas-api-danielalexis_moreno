using System;
using Shared.Events.Domain;

namespace Users.User.Domain;
public class PokemonFavoriteAddedEvent : DomainEvent
{
    public PokemonFavoriteAddedEvent (string aggregateId) : base (aggregateId, String.Empty, "pokemonfavorite.added"){}

}
