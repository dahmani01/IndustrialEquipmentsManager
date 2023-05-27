using CPG_Platform.Dtos.Files;
using CPG_Platform.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPG_Platform.Services.UploadFileService
{
    public interface IUploadFileService
    {
        public Task<serviceResponse<List<UploadResult>>> UploadFile(List<IFormFile> files, int MachineId);
        public Task<serviceResponse<CustomFile>> DownloadFile(string FileName);
    }
}
