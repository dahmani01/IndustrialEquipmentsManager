using CPG_Platform.Data;
using CPG_Platform.Dtos.Files;
using CPG_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPG_Platform.Services.UploadFileService
{
    public class UploadFileService : IUploadFileService
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public UploadFileService(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<serviceResponse<CustomFile>> DownloadFile(string fileName)
        {
            var response = new serviceResponse<CustomFile>();
            var uploadResult = await _context.Documents.FirstOrDefaultAsync(u => u.FileName.Equals(fileName));
            if (uploadResult == null)
            {
                response.Success = false;
                response.Message = "File Not Found.";
                return response;
            }

            var path = Path.Combine(_env.ContentRootPath, "uploads", uploadResult.StoredFileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            CustomFile File = new CustomFile()
            {
                memory = memory,
                ContentType = uploadResult.ContentType,
                Path = Path.GetFileName(path),
            };
            response.Data = File;
            return response;
        }

        public async Task<serviceResponse<List<UploadResult>>> UploadFile(List<IFormFile> files, int MachineId)
        {
            List<UploadResult> uploadResults = new List<UploadResult>();
            serviceResponse<List<UploadResult>> response = new serviceResponse<List<UploadResult>>();

            //Get the machine
            var machine = await _context.Machines.FirstOrDefaultAsync(m => m.Id == MachineId);
            if (machine == null)
            {
                response.Success = false;
                response.Message = "Machine not Found, please verify the MachineId.";
                return response;
            }
            

            foreach (var file in files)
            {
                var uploadResult = new UploadResult();
                string trustedFileNameForFileStorage;
                var untrustedFileName = file.FileName;
                uploadResult.FileName = untrustedFileName;
                //var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);

                trustedFileNameForFileStorage = Path.GetRandomFileName();
                var path = Path.Combine(_env.ContentRootPath, "uploads", trustedFileNameForFileStorage);

                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);

                uploadResult.StoredFileName = trustedFileNameForFileStorage;
                uploadResult.ContentType = file.ContentType;
                /*uploadResult.Machine = machine;*/
                if (machine.Documents == null)
                {
                    var L = new List<UploadResult>() ; 
                    L.Add(uploadResult);
                    machine.Documents = L;
                }
                else
                machine.Documents.Add(uploadResult);

                uploadResults.Add(uploadResult);

                _context.Documents.Add(uploadResult);
            }

            await _context.SaveChangesAsync();
            response.Data = uploadResults;
            return response;
        }
    }
}
