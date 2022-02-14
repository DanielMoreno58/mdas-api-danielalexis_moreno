using Microsoft.AspNetCore.Mvc;
using Users.User.application;
using Users.User.domain;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddPokemonFavoriteController : ControllerBase
    {

        private readonly AddPokemonFavoriteUseCase _addPokemonFavoriteUseCase;

        public AddPokemonFavoriteController(
            AddPokemonFavoriteUseCase addPokemonFavoriteUseCase
        )
        {
            _addPokemonFavoriteUseCase = addPokemonFavoriteUseCase;
        }

        [HttpPost]
        public IActionResult AddPokemonFavorite(Guid userid, Guid pokemonid)
        {
            try
            {
                _addPokemonFavoriteUseCase.Execute(userid, pokemonid);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}