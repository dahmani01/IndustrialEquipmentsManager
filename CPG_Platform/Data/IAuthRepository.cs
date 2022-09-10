using CPG_Platform.Dtos.User;
using CPG_Platform.Models;
using CPG_Platform.Services;

namespace CPG_Platform.Data
{
    public interface IAuthRepository
    {
        public Task<serviceResponse<int>> Register(UserRegisterDto userRegister);
        public Task<serviceResponse<string>> Login(string matricule, string password);

        public Task<bool> UserExists(string username);
    }
}
