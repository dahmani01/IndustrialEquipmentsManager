using AutoMapper;
using CPG_Platform.Data;
using CPG_Platform.Dtos.Service;
using CPG_Platform.Dtos.User;
using CPG_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace CPG_Platform.Services.SeriviceService
{
    public class ServiceService : IServiceService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ServiceService(DataContext context , IMapper mapper , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<serviceResponse<List<GetServiceDto>>> AddNewService(AddNewServiceDto newServiceDto)
        {
            var response = new serviceResponse<List<GetServiceDto>>();
            var service = new Service();
            service.Name = newServiceDto.Name;
            service.Description = newServiceDto.Description;
            service.Secteur = await _context.Sectors.FirstOrDefaultAsync(s => s.SecteurId == newServiceDto.SecteurId);

            if (service.Secteur == null)
            {
                response.Success = false;
                response.Message = "Secteur donne est introuvable.";
                return response;
            }

            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            var services = await _context.Services.Include(s => s.Machines).ToListAsync();
            response.Data = services.Select(s => _mapper.Map<GetServiceDto>(s)).ToList();
            return response;
        }

        public async Task<serviceResponse<List<GetServiceDto>>> GetAllServices(int SectorId)
        {
            var response = new serviceResponse<List<GetServiceDto>>() ;
            response.Data = await _context.Services
                .Where(s => s.Secteur.SecteurId == SectorId)
                .Include(s => s.Machines)   
                .Select(s => _mapper.Map<GetServiceDto>(s)) 
                .ToListAsync();
            if (response.Data ==  null || response.Data.Count == 0)
            {
                response.Success= false;
                response.Message = "Aucun Service trouve dans ce Secteur."; 
                
            }

            return response ;
        }

        public async Task<serviceResponse<GetServiceDto>> GetService(int ServiceId)
        {
            var response = new serviceResponse<GetServiceDto>();
            var service = await _context.Services
                .Include(s => s.Machines)
                .Include(s => s.Users)
                .FirstOrDefaultAsync(s => s.Id == ServiceId);
            if (service == null)
            {
                response.Success = false;
                response.Message = "Service not Found.";
                return response;
            }
            if (!(service.Users == null || service.Users.Count == 0))
            {
                service.Users.Select(u => _mapper.Map<GetUpdatedUserDto>(u)).ToList();
            }
            
            response.Data = _mapper.Map<GetServiceDto>(service);
            return response;
        }

       
    }
}
