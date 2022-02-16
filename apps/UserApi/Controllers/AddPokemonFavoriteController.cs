using Microsoft.AspNetCore.Mvc;
using Users.User.application;
using UserApi.Dto;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class AddPokemonFavoriteController : ControllerBase
    {

        private readonly AddPokemonFavoriteUseCase _addPokemonFavoriteUseCase;

        public AddPokemonFavoriteController(
            AddPokemonFavoriteUseCase addPokemonFavoriteUseCase
        )
        {
            _addPokemonFavoriteUseCase = addPokemonFavoriteUseCase;
        }

        [HttpPost("/User/PokemonFavorite")]
        public IActionResult AddPokemonFavorite([FromBody] AddPokemonFavoriteDto addPokemonFavoriteDto)
        {
            try
            {
                _addPokemonFavoriteUseCase.Execute(addPokemonFavoriteDto.UserId, addPokemonFavoriteDto.PokemonId);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}