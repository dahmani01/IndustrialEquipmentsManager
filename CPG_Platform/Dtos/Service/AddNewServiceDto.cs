using CPG_Platform.Models;

namespace CPG_Platform.Dtos.Service
{
    public class AddNewServiceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SecteurId { get; set; }
    }
}
