using CPG_Platform.Models;

namespace CPG_Platform.Dtos.User
{
    public class GetUpdatedUserDto
    {

        public int Id { get; set; }
        public string Matricule { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool isVerified { get; set; }
        public RoleClass Role { get; set; }
    }
}
