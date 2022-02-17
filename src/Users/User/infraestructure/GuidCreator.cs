namespace Users.User.Infraestructure
{
    public  class GuidCreator
    {
        public static Guid Execute()
        {
            return Guid.NewGuid();
        }
    }
}
