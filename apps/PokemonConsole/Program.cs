using System;
using System.Collections.Generic;
using Pokemon.Type.application;
using Pokemon.Type.domain;
using Pokemon.Type.infraestucture;

namespace PokemonConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
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
                GetTypesByPokemonNameUseCase useCase = new GetTypesByPokemonNameUseCase(new FindByPokemonName(new PokeApiTypeRepository()));
                List<Pokemon.Type.domain.Type> result = useCase.Execute(new GetTypesByPokemonNameQuery(pokemonName));

                string resultString = "";
                foreach (var type in result)
                {
                    resultString += type.Name.Value + (type.Name.Value == result[result.Count - 1].Name.Value ? "" : ", ");
                }
                Console.WriteLine(resultString);
                return;
            }
            catch (PokemonNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            } 
            catch (PokemonApiNotResponseException e) {
                Console.WriteLine(e.Message);
                return;
            }
            catch {
                Console.WriteLine("Oops, something has gone wrong. Try again later.");
            }
        }
    }
}
