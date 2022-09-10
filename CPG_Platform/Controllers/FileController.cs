using CPG_Platform.Data;
using CPG_Platform.Dtos.Files;
using CPG_Platform.Models;
using CPG_Platform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPG_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
      
        private readonly IUploadFileService _service;

        public FileController(IUploadFileService service)
        {
            
            _service = service;
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var response = await _service.DownloadFile(fileName); 
            if (response.Data == null)
            {
                return NotFound("File not Found."); 
            }
            return File(response.Data.memory, response.Data.ContentType, fileName);
        }

        [HttpPost]
        public async Task<ActionResult<List<UploadResult>>> UploadFile(List<IFormFile> files,int MachineId)
        {
            var response = await _service.UploadFile(files,MachineId);
            if (response == null)
            {
                return NotFound(response.Message); 
            }
            return Ok(response); 
        }
    }
}
