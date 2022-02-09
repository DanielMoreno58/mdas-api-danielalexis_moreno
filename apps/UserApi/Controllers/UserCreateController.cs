using Microsoft.AspNetCore.Mvc;
using Users.User.application;
using Users.User.domain;

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
        public IActionResult CreateUser(Guid id, string name)
        {
            try
            {
               _createUserUseCase.Execute(id, name);
                return Ok();
            }
            catch(Exception e)
            {
                return Conflict(e.Message);
            }
        }


    }
}