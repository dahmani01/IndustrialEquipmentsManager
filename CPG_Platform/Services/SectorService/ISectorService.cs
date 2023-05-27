using CPG_Platform.Dtos.SectorDtos;
using CPG_Platform.Models;

namespace CPG_Platform.Services.SectorService
{
    public interface ISectorService
    {
        public Task<serviceResponse<List<Secteur>>> GetAllSectors();
        public Task<serviceResponse<Secteur>> GetSector(int sectorId);
        public Task<serviceResponse<List<Secteur>>> AddNewSector(AddSectorDto sectorDto);
    }
}
