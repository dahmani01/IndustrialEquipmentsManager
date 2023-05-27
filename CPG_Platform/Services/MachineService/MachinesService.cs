using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CPG_Platform.Data;
using CPG_Platform.Models;
using AutoMapper;
using CPG_Platform.Dtos.MachineDtos;

namespace CPG_Platform.Services.MachineService
{
    
    public class MachinesService : IMachineService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MachinesService(DataContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        public async Task<serviceResponse<List<GetMachineDto>>> GetAllMachines()
        {
            var response = new serviceResponse<List<GetMachineDto>>();
            if (_context.Machines == null)
            {
                response.Success = false;
                response.Message = "Aucune Machine Trouve."; 
            }

            response.Data = await _context.Machines
               .Include(m => m.Documents)
               .Include(m => m.entretients)
               .Select(m => _mapper.Map<GetMachineDto>(m))
               .ToListAsync();

            return response; 
        }

        
        public async Task<serviceResponse<GetMachineDto>> GetMachine(int id)
        {
            var response = new serviceResponse<GetMachineDto>();
         
            var machine = await _context.Machines
                .Include(m => m.Documents )
                .FirstOrDefaultAsync(m => m.Id == id);

            if (machine == null)
            {
                response.Success = false;
                response.Message = "Aucune Machine Trouve.";
            }
            response.Data = _mapper.Map<GetMachineDto>( machine);

            return response;
        }

       
        
        public async Task<serviceResponse<GetMachineDto>> UpdateMachine(UpdateMachineDto machine)
        {
            var response = new serviceResponse<GetMachineDto>();
            var Dbmachine = await _context.Machines.FirstOrDefaultAsync(m => m.Id == machine.Id); 
            if (Dbmachine == null)
            {
                response.Success=false;
                response.Message = "No machine was Found with the given Id.";
                return response; 
            }
            var service = await _context.Services.FindAsync(machine.ServiceId); 
            if (service == null)
            {
                response.Success = false;
                response.Message = "No service was Found with the given Id.";
                return response;
            }
            Dbmachine.Name = machine.Name;
            Dbmachine.Description = machine.Description;
            Dbmachine.Service = service;
            Dbmachine.EnService = machine.enService;

            await _context.SaveChangesAsync(); 
            var updatedMachine = await _context.Machines
                .Include(m => m.Documents)
                .FirstOrDefaultAsync(m => m.Id == machine.Id);
            response.Data = _mapper.Map<GetMachineDto>(updatedMachine);
            return response;
        }

        
        public async Task<serviceResponse<GetMachineDto>> AddNewMachine(AddNewMachineDto newMachineDto)
        {

            var response = new serviceResponse<GetMachineDto>();

            var machine = _mapper.Map<Machine>(newMachineDto); 
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();
            int id = machine.Id;
            var newCreated = await _context.Machines.FirstOrDefaultAsync(m => m.Id == id); 
            response.Data = _mapper.Map<GetMachineDto>(newCreated);
            return response;
        }

        
        public async Task<serviceResponse<string>> DeleteMachine(int id)
        {
            var response = new serviceResponse<string>(); 
            if (_context.Machines == null)
            {
                response.Success = false;
                response.Message = "Aucun Machine trouve."; 
                return response;
            }
            var machine = await _context.Machines.FindAsync(id);

            if (machine == null)
            {
                response.Success = false;
                response.Message = "Aucun Machine trouve avec cet Id.";
                return response;
            }

            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();
            response.Data = "Machine Supprimée avec Succes."; 

            return response;
        }

        private bool MachineExists(int id)
        {
            return (_context.Machines?.Any(e => e.Id == id)).GetValueOrDefault();
        }

       
        public async Task<serviceResponse<List<GetMachineDto>>> GetAllMachineEnPanne(int ServiceId)
        {
            var response = new serviceResponse<List<GetMachineDto>>() ; 
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == ServiceId);

            if (service == null)
            {
                response.Success = false;
                response.Message = "Service non trouve.";
                return response; 
            }

            var machinesEnPannes = await _context.Machines
                .Where(e => e.Id == ServiceId && e.EnService == false)
                .Select(m => _mapper.Map<GetMachineDto>(m))
                .ToListAsync();
            if (machinesEnPannes.Count == 0)
            {
                response.Success=false;
                response.Message = "Aucune machine en panne trouvé."; 
                return response;
            }
            response.Data = machinesEnPannes;
            return response; 
        }

       
    }
}
