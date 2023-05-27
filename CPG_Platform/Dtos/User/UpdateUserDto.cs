using CPG_Platform.Models;

namespace CPG_Platform.Dtos.User
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public bool isVerified { get; set; }
        public RoleClass Role { get; set; }
    }
}
