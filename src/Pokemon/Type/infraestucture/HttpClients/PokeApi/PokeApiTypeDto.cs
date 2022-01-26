using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Type.infraestucture.HttpClients.PokeApi
{
    public class PokeApiTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokeApiTypeWrapDto
    {
        public int Slot { get; set; }
        public PokeApiTypeDto Type { get; set; }
    }
}
