namespace Users.User.infraestructure
{
    public  class GuidCreator
    {
        public static Guid Execute()
        {
            return Guid.NewGuid();
        }
    }
}
