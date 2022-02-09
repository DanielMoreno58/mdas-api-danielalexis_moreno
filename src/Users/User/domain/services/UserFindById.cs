namespace Users.User.domain {
    public class UserFindById {
        private readonly IUserRepository _userRepository;

        public UserFindById(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public User Execute(UserId userId) {
            return _userRepository.Find(userId);
        }
    }
}
