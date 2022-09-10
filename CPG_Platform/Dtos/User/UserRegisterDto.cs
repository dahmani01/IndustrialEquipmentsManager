using CPG_Platform.Models;

namespace CPG_Platform.Dtos.User
{
    public class UserRegisterDto
    {
        public string Matricule { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int SecteurId { get; set; }
    }
}
