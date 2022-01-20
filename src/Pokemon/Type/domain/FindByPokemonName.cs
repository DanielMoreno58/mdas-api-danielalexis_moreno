namespace Pokemon.Type.domain {

    public class FindByPokemonName {
        private readonly TypeRepository _typeRepository;
        public FindByPokemonName(TypeRepository typeRepository) {
            _typeRepository = typeRepository;
        }
        
        public List<Type> Execute(PokemonName name) {
            var types = repository.FindByPokemonName(query.Name());
            if (types.Count == 0)
            {
                throw new PokemonNotFoundException();
            }
            return types;
        }
    }
}
