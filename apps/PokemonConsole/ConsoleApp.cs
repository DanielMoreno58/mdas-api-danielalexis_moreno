using Pokemon.Type.application;
using Pokemon.Type.domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class ConsoleApp
    {
        private readonly GetTypesByPokemonNameUseCase _getTypesByPokemonNameUseCase;
        public ConsoleApp(GetTypesByPokemonNameUseCase getTypesByPokemonNameUseCasey)
        {
            _getTypesByPokemonNameUseCase = getTypesByPokemonNameUseCasey;
        }
        public async Task RunAsync()
        {
            try
            {
                string pokemonName = string.Empty;
                do
                {
                    Console.WriteLine("Enter the name of the pokemon");
                    pokemonName = Console.ReadLine();
                    if (pokemonName == string.Empty)
                    {
                        Console.WriteLine("Name is required");
                    }
                } while (pokemonName == string.Empty);
                List<Pokemon.Type.domain.Type> result = _getTypesByPokemonNameUseCase.Execute(new GetTypesByPokemonNameQuery(pokemonName));

                string resultString = "";
                foreach (var type in result)
                {
                    resultString += type.Name.Value + (type.Name.Value == result[result.Count - 1].Name.Value ? "" : ", ");
                }
                Console.WriteLine(resultString);
                return;
            }
            catch (Exception e)
            {
                if (e.InnerException.GetType().Equals(typeof(PokemonNotFoundException)))
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                if (e.InnerException.GetType().Equals(typeof(PokemonApiNotResponseException)))
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                Console.WriteLine("Oops, something has gone wrong. Try again later.");
            }

            await Task.Delay(0);
        }
    }
}
