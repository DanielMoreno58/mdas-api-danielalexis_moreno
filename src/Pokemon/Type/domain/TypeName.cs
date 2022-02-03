namespace Pokemon.Type.domain
{
    public readonly struct TypeName
    {
        public string Value { get; } 
        
        public TypeName(string name)
        {
            Value = name;
        }
    }
}
