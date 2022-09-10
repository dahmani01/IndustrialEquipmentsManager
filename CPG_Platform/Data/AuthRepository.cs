using CPG_Platform.Data;
using CPG_Platform.Dtos.User;
using CPG_Platform.Models;
using CPG_Platform.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CPG_Platform.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<serviceResponse<string>> Login(string matricule, string password)
        {
            var response = new serviceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Matricule.Trim().Equals(matricule.Trim())); 
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash,user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password."; 
            }
            else
            {
                response.Data = CreateToken(user);
            }
            return response; 
        }

        public async Task<serviceResponse<int>> Register(UserRegisterDto userRegister)
        {
            var ServiceResponse = new serviceResponse<int>();
            
            if (await UserExists(userRegister.Matricule))
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "Matricule already exists.";
                return ServiceResponse; 
            }

            else
            {
                var user = new User { Matricule = userRegister.Matricule };
                var Secteur = await _context.Sectors.FindAsync(userRegister.SecteurId);
                CreatePasswordHash(userRegister.Password, out byte[] passwordHash, out byte[] passwordSalt); 
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.PhoneNumber = userRegister.PhoneNumber;
                user.FirstName = userRegister.FirstName;
                user.LastName = userRegister.LastName;
                user.Secteur = Secteur; 

                 _context.Users.Add(user);
                await _context.SaveChangesAsync();
                ServiceResponse.Data = user.Id; 
                return ServiceResponse; 
            }


        }

        public async Task<bool> UserExists(string matricule)
        {
            if (await _context.Users.AnyAsync(u => u.Matricule == matricule))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password , out byte[] passwordHash , out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash , byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) ,
                new Claim(ClaimTypes.Name, user.FirstName+" "+user.LastName),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            } ;

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler(); 
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token); 
        }
    }
}
