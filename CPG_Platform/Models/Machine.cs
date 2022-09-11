namespace CPG_Platform.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PurshaseDate  { get; set; }
        public bool EnService { get; set; } = true;
        public Service? Service { get; set; }
        public List<Entretient>? entretients { get; set; }
        public List<PieceRechange>? PieceRechanges { get; set; }
        public List<UploadResult>? Documents { get; set; }
    }
}
