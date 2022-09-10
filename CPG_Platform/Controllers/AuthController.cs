using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CPG_Platform.Data;
using CPG_Platform.Dtos.User;
using CPG_Platform.Services;
using CPG_Platform.Models;

namespace CPG_Platform.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;

        public AuthController(IAuthRepository auth)
        {
            _auth = auth;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<serviceResponse<int>>> Register(UserRegisterDto request)
        {
           var response = await _auth.Register(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<serviceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _auth.Login(request.Matricule , request.Password);
            if (response.Success) { return Ok(response); }
            else { return BadRequest(response); }
        }

    }
}
