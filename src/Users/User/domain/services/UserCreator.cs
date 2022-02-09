namespace Users.User.domain
{
    public class UserCreator
    {
        private readonly IUserRepository _userRepository;

        public UserCreator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(UserId userId, UserName userName)
        {
            var user = User.Create(userId, userName);
            _userRepository.Save(user);
        }
    }
}
