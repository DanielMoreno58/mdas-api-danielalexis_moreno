using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Type.infraestucture.HttpClients.PokeApi
{
    internal class PokeApiPokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<PokeApiTypesDto> Types { get; set; }
    }
}
