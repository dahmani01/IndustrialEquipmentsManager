namespace CPG_Platform.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }    
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool isVerified { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public RoleClass Role { get; set; }
        public Secteur Secteur { get; set; }
        public List<Entretient>? Entretients { get; set; }
        
    }
}
