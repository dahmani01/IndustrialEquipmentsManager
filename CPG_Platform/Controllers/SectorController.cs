using CPG_Platform.Dtos.SectorDtos;
using CPG_Platform.Models;
using CPG_Platform.Services;
using CPG_Platform.Services.SectorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPG_Platform.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService _service;

        public SectorController(ISectorService service)
        {
            _service = service;
        }
        [HttpGet("GetSector")]
        public async Task<ActionResult<serviceResponse<Secteur>>> GetSector(int sectorId)
        {
            var response = await _service.GetSector(sectorId);
            if (response.Data == null)
            {
                return NotFound(response.Message);
            }
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpGet("GetAllSectors")]
        public async Task<ActionResult<serviceResponse<List<Secteur>>>> GetAllSectors()
        {
            var response = await _service.GetAllSectors();
            if (response.Data == null)
            {
                return NotFound(response.Message);
            }
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<serviceResponse<List<Secteur>>>> AddNewSector(AddSectorDto sectorDto)
        {
            var response = await _service.AddNewSector(sectorDto);
            if (response.Data == null)
            {
                return NotFound(response.Message);
            }
            return Ok(response);
        }
    }
}
