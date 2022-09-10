namespace CPG_Platform.Models
{
    public class Secteur
    {
        public int SecteurId { get; set; }
        public string SecteurName { get; set; }
        public string Description { get; set; }
        public List<Service>? Services { get; set; }
        
    }
}
