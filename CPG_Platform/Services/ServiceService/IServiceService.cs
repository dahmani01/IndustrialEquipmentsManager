using CPG_Platform.Dtos.Service;
using CPG_Platform.Models;

namespace CPG_Platform.Services.SeriviceService
{
    public interface IServiceService
    {
        public Task<serviceResponse<List<GetServiceDto>>> AddNewService(AddNewServiceDto newServiceDto);
        public Task<serviceResponse<List<GetServiceDto>>> GetAllServices(int SectorId);
        public Task<serviceResponse<GetServiceDto>> GetService(int ServiceId);
    }
}
