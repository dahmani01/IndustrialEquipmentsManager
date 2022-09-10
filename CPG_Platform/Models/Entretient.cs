using System.Reflection.PortableExecutable;

namespace CPG_Platform.Models
{
    public class Entretient
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Machine Machine { get; set; }

    }
}
