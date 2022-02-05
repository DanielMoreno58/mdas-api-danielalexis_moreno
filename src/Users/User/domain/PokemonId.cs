namespace Users.User.domain
{
    public readonly struct PokemonId
    {
        public Guid Value { get; } 
        
        public PokemonId(Guid id)
        {
            Value = id;
        }
    }
}
