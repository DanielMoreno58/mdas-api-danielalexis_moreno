namespace Users.User.domain
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() 
            : base("User already exists")
        {
        }
    }
}