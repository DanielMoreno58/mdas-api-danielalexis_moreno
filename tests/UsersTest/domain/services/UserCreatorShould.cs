using Moq;
using System;
using Users.User.domain;
using Users.User.infraestructure;
using Xunit;

namespace UsersTest.domain.services
{
    public class UserCreatorShould
    {
       // private readonly IUserRepository _userRepository;
        private UserCreator? _creator;


        [Fact]
        public void Should_Create_A_User()
        {
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Exists(It.IsAny<UserId>())).Returns(false);
            _creator = new UserCreator(userRepository.Object);

            //Given
            var userId = UserIdMother.Random();
            var userName = UserNameMother.Random();

            //When
            _creator.Execute(userId, userName);

            //Then
            var user = UserMother.Random(userId,userName);
            
            //funciona
            userRepository.Verify(v => v.Save(It.IsAny<User>())); 

            //no funciona
            userRepository.Verify(v => v.Save(user));
        }

        [Fact]
        public void Should_Throw_An_Exception_When_User_Already_Exists()
        {
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Exists(It.IsAny<UserId>())).Returns(true);
            _creator = new UserCreator(userRepository.Object);

            //Given
            var userId = UserIdMother.Random();
            var userName = UserNameMother.Random();

            //When - Then
            Assert.Throws<UserAlreadyExistsException>(() => _creator.Execute(userId, userName)); 
        }
    }
}
 