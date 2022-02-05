namespace Users.User.domain
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException() 
            : base("User does not exist")
        {
        }
    }
}
