using CPG_Platform.Dtos.EntretientDtos;
using CPG_Platform.Models;
using CPG_Platform.Services;
using CPG_Platform.Services.EntretientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPG_Platform.Controllers
{
    [Authorize(Roles ="Admin,Manager,Ouvrier")]
    [Route("api/[controller]")]
    [ApiController]
    public class EntretientController : ControllerBase
    {
        private readonly IEntretientService _service;

        public EntretientController(IEntretientService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<serviceResponse<GetEntretientDto>>> AddNewEntretient(AddNewEntretientDto newEntretientDto)
        {
            var response = await _service.AddNewEntretient(newEntretientDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
