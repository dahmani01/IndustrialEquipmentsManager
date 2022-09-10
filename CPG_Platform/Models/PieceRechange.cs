namespace CPG_Platform.Models
{
    public class PieceRechange
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public Machine Machine { get; set; }
        public int Quantite { get; set; }
    }
}
