using CPG_Platform.Dtos.EntretientDtos;
using CPG_Platform.Models;

namespace CPG_Platform.Services.EntretientService
{
    public interface IEntretientService
    {
        public Task<serviceResponse<GetEntretientDto>> AddNewEntretient(AddNewEntretientDto newEntretientDto);
    }
}
