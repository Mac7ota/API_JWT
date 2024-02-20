using DefaultNamespace.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DefaultNamespace
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("adicionar-vendedor", Name = "adicionar-vendedor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AddUser(User user)
        {
            _userService.AddUser(user);
            return Ok("User added successfully");
        }
    }
}