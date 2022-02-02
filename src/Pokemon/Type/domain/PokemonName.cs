namespace Pokemon.Type.domain
{
    public readonly struct PokemonName
    {
        public string Value { get; } 
        
        public PokemonName(string name)
        {
            Value = name;
        }
    }
}
