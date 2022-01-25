using Microsoft.AspNetCore.Mvc;
using Pokemon.Type.application;
using Pokemon.Type.domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TypeGetController : ControllerBase
    {
        private readonly GetTypesByPokemonNameUseCase _getTypesByPokemonNameUseCase;

        public TypeGetController(GetTypesByPokemonNameUseCase getTypesByPokemonNameUseCase)
        {
            _getTypesByPokemonNameUseCase = getTypesByPokemonNameUseCase;
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            if (name == string.Empty)
            {
                return BadRequest("Names is required");
            }
            try
            {
                var getTypesByPokemonNameQuery = TypeGetAdapter.GetByPokemonNameToGetTypesByPokemonNameQuery(name);
                List<Pokemon.Type.domain.Type> result = _getTypesByPokemonNameUseCase.Execute(getTypesByPokemonNameQuery);

                return Ok(result);
            }
            catch (PokemonNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (PokemonApiNotResponseException e) {
                return Conflict(e.Message);
            }
            catch (Exception)
            {
                return NotFound("Oops, something has gone wrong. Try again later.");
            }
        }

    }
}
