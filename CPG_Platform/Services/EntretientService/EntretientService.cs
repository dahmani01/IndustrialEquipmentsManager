using CPG_Platform.Data;
using CPG_Platform.Dtos.EntretientDtos;
using CPG_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace CPG_Platform.Services.EntretientService
{
    public class EntretientService : IEntretientService
    {
        private readonly DataContext _context;

        public EntretientService(DataContext context)
        {
            _context = context;
        }
        public async Task<serviceResponse<GetEntretientDto>> AddNewEntretient(AddNewEntretientDto newEntretientDto)
        {
            var response = new serviceResponse<GetEntretientDto>();
            var machine = await _context.Machines.FirstOrDefaultAsync(m => m.Id == newEntretientDto.MachineId); 
            if (machine == null)
            {
                response.Success = false;
                response.Message = "Machine Not Found";
                return response; 
            }
            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == newEntretientDto.UserId);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User Not Found";
                return response;
            }

            var ent = new Entretient(); 
            ent.User = user;
            ent.Machine = machine;
            ent.Date = newEntretientDto.Date;
            ent.Description = newEntretientDto.Description; 

            _context.Entretients.Add(ent);
            await _context.SaveChangesAsync();
            var createdId = ent.Id; 
            response.Data = await _context.Entretients
                .Select(e => new GetEntretientDto
                {
                    Id = e.Id,
                    Date = e.Date,
                    Description= e.Description,
                    UserFirstName= e.User.FirstName,
                    UserLastName = e.User.LastName,
                    UserMatricule =e.User.Matricule,
                    MachineName = e.Machine.Name,
                    MachineId = e.Machine.Id,
                })
                .FirstOrDefaultAsync(e => e.Id == createdId);
            return response; 

        }
    }
}
