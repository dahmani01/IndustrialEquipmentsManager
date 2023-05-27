using CPG_Platform.Dtos.User;
using CPG_Platform.Models;

namespace CPG_Platform.Dtos.Service
{
    public class GetServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<GetUpdatedUserDto> Users { get; set; } 
        public List<Machine>? Machines { get; set; }
    }
}
