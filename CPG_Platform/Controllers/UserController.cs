using CPG_Platform.Dtos.User;
using CPG_Platform.Services;
using CPG_Platform.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPG_Platform.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPut]
        public async Task<ActionResult<serviceResponse<GetUpdatedUserDto>>> UpdateUser(UpdateUserDto updateUserDto)
        {
            var response = await _service.UpdateUser(updateUserDto);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response);
        }
        [HttpDelete]
        public async Task<ActionResult<serviceResponse<List<GetUserDto>>>> DeleteUser(int id)
        {
            var response = await _service.DeleteUser(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<serviceResponse<GetUserDto>>> GetUserById(int id)
        {
            var response = await _service.GetUserById(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response);
        }
    }
}
