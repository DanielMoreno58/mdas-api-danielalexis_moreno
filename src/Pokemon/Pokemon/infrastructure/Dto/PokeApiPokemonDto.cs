
namespace Pokemon.Pokemon.Infrastructure
{
    public class PokeApiPokemonDto
    {
        public PokeApiPokemonDto()
        {

        }

        public PokeApiPokemonDto(int id, string name, int height, int weight,int counter) : this()
        {
            Id = id;
            Name = name;
            Height = height;
            Weight = weight;
            Counter = counter;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Counter { get; set; }
    }
}
