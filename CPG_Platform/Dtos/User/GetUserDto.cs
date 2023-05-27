using CPG_Platform.Models;

namespace CPG_Platform.Dtos.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SectorId { get; set; }
        public bool isVerified { get; set; }
    }
}
