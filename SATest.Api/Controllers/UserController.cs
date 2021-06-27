using Microsoft.AspNetCore.Mvc;
using SATest.Application.Services;
using SATest.Models.DTO;
using System.Threading.Tasks;

namespace SATest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userService.GetUserById(id);
            if(result == null)
            {
                return NotFound("Can't find user");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserForCreationDto userForCreationDto)
        {
            var id = await _userService.CreateUser(userForCreationDto);
            return CreatedAtAction("GetUserById", new { id }, userForCreationDto);
        }
    }
}
