using CPG_Platform.Data;
using CPG_Platform.Dtos.SectorDtos;
using CPG_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace CPG_Platform.Services.SectorService
{
    public class SectorService : ISectorService
    {
        private readonly DataContext _context;

        public SectorService(DataContext context)
        {
            _context = context;
        }
        public async Task<serviceResponse<List<Secteur>>> AddNewSector(AddSectorDto sectorDto)
        {
            var serviceResponse = new serviceResponse<List<Secteur>>();
            Secteur secteur = new Secteur();
            secteur.SecteurName = sectorDto.SecteurName;
            secteur.Description = sectorDto.Description;

            _context.Sectors.Add(secteur);
            await _context.SaveChangesAsync();
            var sectors = await _context.Sectors.Include(s => s.Services).ToListAsync();
            serviceResponse.Data = sectors;
            return serviceResponse;


        }

        public async Task<serviceResponse<List<Secteur>>> GetAllSectors()
        {
            var serviceResponse = new serviceResponse<List<Secteur>>();
            var sectors = await _context.Sectors.Include(s => s.Services).ToListAsync();
            serviceResponse.Data = sectors;
            return serviceResponse;

        }

        public async Task<serviceResponse<Secteur>> GetSector(int sectorId)
        {
            var serviceResponse = new serviceResponse<Secteur>();
            var secteur = await _context.Sectors
                .Include(s => s.Services)
                .FirstOrDefaultAsync(s => s.SecteurId == sectorId);
            if (secteur == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Sector not Found.";
            }
            serviceResponse.Data = secteur;
            return serviceResponse;
        }
    }
}
