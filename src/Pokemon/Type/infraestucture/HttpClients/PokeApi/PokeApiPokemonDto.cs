using System.Collections.Generic;

namespace Pokemon.Type.Infraestucture
{
    internal class PokeApiPokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<PokeApiTypesDto> Types { get; set; }
    }
}
