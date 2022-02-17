using System.Collections.Generic;
using Moq;
using Pokemon.Type.Application;
using Pokemon.Type.Domain;
using TypeTest.Domain;
using Xunit;

namespace TypeTest.Application
{
    public class GetTypesByPokemonNameUseCaseTest
    {
        [Fact]
        public void Should_Return_A_Types_By_PokemonName()
        {
            var typeRepository = new Mock<ITypeRepository>();
            var type = TypeMother.Random();
            typeRepository.Setup(_ => _.FindByPokemonName(It.IsAny<PokemonName>())).Returns(new List<Type>() { type });
            var findByPokemonName = new Mock<FindByPokemonName>(typeRepository.Object);
            var getTypesByPokemonNameUseCase = new GetTypesByPokemonNameUseCase(findByPokemonName.Object);

            var result = getTypesByPokemonNameUseCase.Execute(new GetTypesByPokemonNameQuery("pikachu"));

            Assert.Equal(type.Name, result[0].Name);
        }
    }
}
