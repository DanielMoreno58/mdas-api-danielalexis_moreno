using System;

namespace Pokemon.Type.application
{
    public class GetTypesByPokemonNameUseCase
    {
        public GetTypesByPokemonNameUseCase(GetTypesByPokemonNameQuery query)
        {
            var repository = new TypeRepository();
            var types = repository.FindByPokemonName(query.Name());
            if (types.Count == 0)
            {
                throw new PokemonNotFoundException();
            }
            return types;
        }
    }
}
