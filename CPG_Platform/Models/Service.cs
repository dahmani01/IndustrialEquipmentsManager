namespace CPG_Platform.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Secteur Secteur { get; set; }
        public List<User>? Users { get; set; }
        public List<Machine>? Machines { get; set; }
    }
}
