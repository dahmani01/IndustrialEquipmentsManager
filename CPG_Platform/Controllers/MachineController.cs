using CPG_Platform.Dtos.MachineDtos;
using CPG_Platform.Models;
using CPG_Platform.Services;
using CPG_Platform.Services.MachineService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPG_Platform.Controllers
{
    [Authorize(Roles ="Admin,Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IMachineService _service;

        public MachineController(IMachineService service)
        {
            _service = service;
        }
        [HttpGet("GetMachine")]
        public async Task<ActionResult<serviceResponse<GetMachineDto>>> GetMachine(int id)
        {
            var response = await _service.GetMachine(id);
            if (!response.Success) { return NotFound(response.Message); }
            return Ok(response);
        }

        [HttpGet("GetAllMachines")]
        public async Task<ActionResult<serviceResponse<List<GetMachineDto>>>> GetAllMachines()
        {
            var response = await _service.GetAllMachines();
            if (!response.Success) { return NotFound(response.Message); }
            return Ok(response);

        }


        [HttpGet("GetAllMachineEnPanne")]
        public async Task<ActionResult<serviceResponse<List<GetMachineDto>>>> GetAllMachineEnPanne(int ServiceId)
        {
            var response = await _service.GetAllMachineEnPanne(ServiceId);
            if (!response.Success) 
            { 
                return NotFound(response.Message); 
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<serviceResponse<GetMachineDto>>> UpdateMachine(UpdateMachineDto updateMachineDto)
        {
            var response = await _service.UpdateMachine(updateMachineDto);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response);

        }

            
        [HttpPost]
        public async Task<ActionResult<serviceResponse<GetMachineDto>>> AddNewMachine(AddNewMachineDto addNewMachineDto)
        {
            var response = await _service.AddNewMachine(addNewMachineDto);
            
            return Ok(response);
        }
        
        
        
        [HttpDelete]
        public async Task<ActionResult<serviceResponse<string>>> DeleteMachine(int id)
        {
            var response = await _service.DeleteMachine(id);
            if (!response.Success)
            {
                return NotFound(response.Message);
            }
            return Ok(response);
        }
    }
}
