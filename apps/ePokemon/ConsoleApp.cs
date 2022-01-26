using Pokemon.Type.application;
using Pokemon.Type.domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ePokemon
{
    public class ConsoleApp
    {
        private readonly GetTypesByPokemonNameUseCase _getTypesByPokemonNameUseCase;
        public ConsoleApp(GetTypesByPokemonNameUseCase getTypesByPokemonNameUseCasey)
        {
            _getTypesByPokemonNameUseCase= getTypesByPokemonNameUseCasey;
        }
        public async Task RunAsync()
        {
            Console.WriteLine("What is your name?");
            string pokemonName = Console.ReadLine();
            List<Pokemon.Type.domain.Type> result = _getTypesByPokemonNameUseCase.Execute(new GetTypesByPokemonNameQuery(pokemonName));
            string resultString = "";
            foreach (var type in result)
            {
                resultString += type.Name.Value + (type.Name.Value == result[result.Count - 1].Name.Value ? "" : ", ");
            }
            Console.WriteLine(resultString);

            await Task.Delay(0);
        }
    }
}
