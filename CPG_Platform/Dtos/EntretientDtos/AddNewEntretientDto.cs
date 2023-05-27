using CPG_Platform.Models;

namespace CPG_Platform.Dtos.EntretientDtos
{
    public class AddNewEntretientDto
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int MachineId { get; set; }
    }
}
