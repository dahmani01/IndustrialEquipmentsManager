using CPG_Platform.Models;

namespace CPG_Platform.Dtos.MachineDtos
{
    public class GetMachineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PurshaseDate { get; set; }
        public bool EnService { get; set; } = true;
        public List<Entretient>? entretients { get; set; }
       
        public List<UploadResult>? Documents { get; set; }
    }
}
