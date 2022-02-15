using Microsoft.AspNetCore.Mvc;
using Users.User.application;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCreateController : ControllerBase
    {

        private readonly CreateUserUseCase _createUserUseCase;

        public UserCreateController(
            CreateUserUseCase createUserUseCase
        )
        {
            _createUserUseCase = createUserUseCase;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]string name, [FromBody]Guid id)
        {
            if (string.IsNullOrEmpty(name) || id == null)
            {
                return BadRequest();
            }
            try
            {
               _createUserUseCase.Execute(id,name);
                return Ok();
            }
            catch(Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}