using Moq;
using Users.User.domain;
using Xunit;

namespace UsersTest.domain.services
{
    public class UserCreatorShould
    {
        private UserCreator? _userCreator;

        [Fact]
        public void Create_A_User()
        {
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Exists(It.IsAny<UserId>())).Returns(false);
            _userCreator = new UserCreator(userRepository.Object);

            //Given
            var userId = UserIdMother.Random();
            var userName = UserNameMother.Random();

            //When
            _userCreator.Execute(userId, userName);

            //Then
            userRepository.Verify(v => v.Save(It.IsAny<User>())); 
        }

        [Fact]
        public void Throw_An_Exception_When_User_Already_Exists()
        {
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Exists(It.IsAny<UserId>())).Returns(true);
            _userCreator = new UserCreator(userRepository.Object);

            //Given
            var userId = UserIdMother.Random();
            var userName = UserNameMother.Random();

            //When - Then
            Assert.Throws<UserAlreadyExistsException>(() => _userCreator.Execute(userId, userName)); 
        }
    }
}
 