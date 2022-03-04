using System;
using Shared.Events.Domain;

namespace Pokemon.Pokemon.Infrastructure
{
    public class PokemonFavoriteSuscribeAddedEvent : DomainEvent
    {
        public PokemonFavoriteSuscribeAddedEvent(string aggregateId) : base(aggregateId, String.Empty, "pokemonfavorite.added") { }

    }
}

