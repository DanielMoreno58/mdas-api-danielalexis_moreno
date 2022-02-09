namespace Users.User.domain {
    public class UserExistById {
        private readonly IUserRepository _userRepository;

        public UserExistById(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public bool Execute(UserId userId) {
            return _userRepository.Exists(userId);
        }
    }
}
