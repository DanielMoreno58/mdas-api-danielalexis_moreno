namespace UserApi.Dto {
    public class AddPokemonFavoriteDto {
        public Guid UserId { get; set; }
        public Guid PokemonId { get; set; }
    }
}
