using CPG_Platform.Dtos.Service;
using CPG_Platform.Models;
using CPG_Platform.Services;
using CPG_Platform.Services.SeriviceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPG_Platform.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<serviceResponse<List<Service>>>> AddNewService(AddNewServiceDto newServiceDto)
        {
            return Ok( await _service.AddNewService(newServiceDto)); 
        }
        [HttpGet("GetAllServices")]
        public async Task<ActionResult<serviceResponse<List<GetServiceDto>>>> GetAllServices(int SectorId)
        {
            var response = await _service.GetAllServices(SectorId);
            if(!response.Success) 
                return NotFound(response.Message);
            return Ok(response);
        }
        [HttpGet("GetService")]
        public async Task<ActionResult<serviceResponse<GetServiceDto>>> GetService(int ServiceId)
        {
            var response = await _service.GetService(ServiceId);
            if (!response.Success)
                return NotFound(response.Message);
            return Ok(response); 
        }
    }
}
