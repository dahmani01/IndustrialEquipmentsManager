
using CPG_Platform.Dtos.MachineDtos;

namespace CPG_Platform.Services.MachineService
{
    public interface IMachineService
    {
        public Task<serviceResponse<GetMachineDto>> GetMachine(int id);
        public Task<serviceResponse<List<GetMachineDto>>> GetAllMachines();
        public Task<serviceResponse<List<GetMachineDto>>> GetAllMachineEnPanne(int ServiceId);
        
        public Task<serviceResponse<GetMachineDto>> UpdateMachine(UpdateMachineDto updateMachineDto); 
        public Task<serviceResponse<GetMachineDto>> AddNewMachine(AddNewMachineDto addNewMachineDto);
        public Task<serviceResponse<string>> DeleteMachine(int id);
    }
}