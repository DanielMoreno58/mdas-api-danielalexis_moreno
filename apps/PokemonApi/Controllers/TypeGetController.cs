using Microsoft.AspNetCore.Mvc;
using Pokemon.Type.Application;
using Pokemon.Type.Domain;

namespace PokemonApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class TypeGetController : ControllerBase
    {
        private readonly GetTypesByPokemonNameUseCase _getTypesByPokemonNameUseCase;

        public TypeGetController(GetTypesByPokemonNameUseCase getTypesByPokemonNameUseCase)
        {
            _getTypesByPokemonNameUseCase = getTypesByPokemonNameUseCase;
        }

        [HttpGet("type/{name}")]
        public IActionResult Get(string name)
        {
            if (name == string.Empty)
            {
                return BadRequest("Name is required");
            }
            try
            {
                var getTypesByPokemonNameQuery = TypeGetAdapter.GetByPokemonNameToGetTypesByPokemonNameQuery(name);
                List<Pokemon.Type.Domain.Type> result =
                    _getTypesByPokemonNameUseCase.Execute(getTypesByPokemonNameQuery);

                return Ok(result);
            }
            catch (Exception e)
            {
                if (e.InnerException is PokemonNotFoundException)
                    return NotFound(e.Message);
                if (e.InnerException is TypeRepositoryIsNotRespondingException)
                    return Conflict(e.Message);
                return NotFound("Oops, something has gone wrong. Try again later.");
            }
        }
    }
}
