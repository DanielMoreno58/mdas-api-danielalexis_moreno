using Users.User.domain;

namespace Users.User.application
{
    public class CreateUserUseCase
    {
        private readonly UserCreator _userCreator;
        private readonly UserExistById _userExistById;

        public CreateUserUseCase(UserCreator userCreator, UserExistById userExistById)
        {
            _userCreator = userCreator;
            _userExistById = userExistById;
        }

        public void Execute(Guid id, string name)
        {
            UserId userId = new UserId(id);
            UserName userName = new UserName(name);

            GuardAgainstUserAlreadyExists(userId);
            _userCreator.Create(userId, userName);
        }

        private void GuardAgainstUserAlreadyExists(UserId userId)
        {
            if (_userExistById.Execute(userId))
            {
                throw new UserAlreadyExistsException();
            }
        }
    }
}
