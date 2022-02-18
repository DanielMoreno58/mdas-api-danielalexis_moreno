using Microsoft.AspNetCore.Mvc;
using Pokemon.Pokemon.Application;
using Pokemon.Pokemon.Domain;
using Pokemon.Type.Domain;
using PokemonNotFoundException = Pokemon.Pokemon.Domain.PokemonNotFoundException;

namespace PokemonApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class PokemonGetController : ControllerBase
    {
        private readonly GetPokemonByPokemonIdUseCase _getPokemonByPokemonIdUseCase;

        public PokemonGetController(GetPokemonByPokemonIdUseCase getPokemonByPokemonIdUseCase)
        {
            _getPokemonByPokemonIdUseCase = getPokemonByPokemonIdUseCase;
        }

        [HttpGet("pokemon/{id:int}")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Oops, something has gone wrong with request. Correct your call and try again");

            }

            try
            {
                Pokemon.Pokemon.Domain.Pokemon result = _getPokemonByPokemonIdUseCase.Execute(id);

                return Ok(result);
            }
            catch (Exception e)
            {
                if (e.InnerException.GetType().Equals(typeof(PokemonNotFoundException)))
                    return NotFound(e.Message);

                if (e.InnerException.GetType().Equals(typeof(PokemonRepositoryIsNotRespondingException)))
                    return Conflict(e.Message);

                return NotFound("Oops, something has gone wrong. Try again later.");
            }
        }

    }
}
