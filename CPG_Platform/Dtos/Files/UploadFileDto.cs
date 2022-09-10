using CPG_Platform.Models;

namespace CPG_Platform.Dtos.Files
{
    public class UploadFileDto
    {
        public List<IFormFile> files; 
        public int MachineId;
    }
}
