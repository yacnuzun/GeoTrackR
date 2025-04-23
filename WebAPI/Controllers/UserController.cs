using Application.Service;
using Core.DTO;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetUserByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(UserDTO userDto)
        //{
        //    var createdUser = await _userService.CreateUserAsync(userDto);
        //    return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _userService.DeleteAsync(id);
        //    if (!result)
        //        return NotFound();

        //    return NoContent();
        //}
    }
}
