using Moq;
using Users.User.application;
using Users.User.domain;
using Users.User.infraestructure;
using UsersTest.domain;
using Xunit;

namespace UsersTest.application
{
    public class AddPokemonFavoriteUseCaseTest
    {
        [Fact]
        public void Should_Add_A_PokemonFavorite()
        {
            //Given
            var userGuid = GuidCreator.Execute();
            var pokemonId = GuidCreator.Execute();
            var userId = UserIdMother.Random(userGuid);
            var user = UserMother.Random(userId, It.IsAny<UserName>());

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(_ => _.Exists(It.IsAny<UserId>())).Returns(true);
            userRepository.Setup(_ => _.Find(It.IsAny<UserId>())).Returns(user);

            var userAddPokemonFavorite = new Mock<UserAddPokemonFavorite>(userRepository.Object);
            var addPokemonFavoriteUseCase = new AddPokemonFavoriteUseCase(userAddPokemonFavorite.Object);

            //When
            addPokemonFavoriteUseCase.Execute(userGuid, pokemonId);

            //Then
            userAddPokemonFavorite.Verify(v => v.Execute(It.IsAny<UserId>(), It.IsAny<PokemonFavorite>()));
        }
    }
}