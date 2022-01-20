using System;

namespace ePokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            var pokemonName = Console.ReadLine();
            Console.WriteLine("Lo siento " + pokemonName + ", but this game is not ready yet.");
        }
    }
}
