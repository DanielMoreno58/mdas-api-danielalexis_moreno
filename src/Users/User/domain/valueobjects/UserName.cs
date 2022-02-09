namespace Users.User.domain
{
    public readonly struct UserName
    {
        public string Value { get; } 
        
        public UserName(string name)
        {
            Value = name;
        }
    }
}
