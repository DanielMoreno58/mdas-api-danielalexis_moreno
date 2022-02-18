using System.Collections.Generic;
using Moq;
using Pokemon.Type.Domain;
using Xunit;

namespace TypeTest.Domain
{
    public class FindByPokemonNameShould
    {
        [Fact]
        public void Return_A_Types_By_PokemonName()
        {
            var typeRepository = new Mock<ITypeRepository>();
            var type = TypeMother.Random();
            typeRepository.Setup(_ => _.FindByPokemonName(It.IsAny<PokemonName>())).Returns(new List<Type>() { type });
            var _findByPokemonName = new FindByPokemonName(typeRepository.Object);

            var result = _findByPokemonName.Execute(PokemonNameMother.Random());

            Assert.Equal(type.Name, result[0].Name);
        }

        [Fact]
        public void Throw_An_Exception_When_Pokemon_Does_Not_Exists()
        {
            var typeRepository = new Mock<ITypeRepository>();
            typeRepository.Setup(_ => _.FindByPokemonName(It.IsAny<PokemonName>())).Returns(new List<Type>());
            var _findByPokemonName = new FindByPokemonName(typeRepository.Object);

            Assert.Throws<PokemonNotFoundException>(() => _findByPokemonName.Execute(PokemonNameMother.Random()));
        }
    }
}