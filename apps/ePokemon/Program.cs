using System;
using System.Collections.Generic;
using Pokemon.Type.application;
using Pokemon.Type.domain;
using Pokemon.Type.infraestucture;

namespace ePokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string pokemonName = Console.ReadLine();
            GetTypesByPokemonNameUseCase useCase = new GetTypesByPokemonNameUseCase(new FindByPokemonName(new PokeApiTypeRepository()));
            List<Pokemon.Type.domain.Type> result = useCase.Execute(new GetTypesByPokemonNameQuery(pokemonName));
            string resultString = "";
            foreach (var type in result)
            {
                resultString += type.Name.Value + (type.Name.Value == result[result.Count - 1].Name.Value ? "" : ", ");
            }
            Console.WriteLine(resultString);
        }
    }
}
