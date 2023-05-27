using CPG_Platform.Dtos.User;

namespace CPG_Platform.Services.UserService
{
    public interface IUserService
    {
        public Task<serviceResponse<GetUpdatedUserDto>> UpdateUser(UpdateUserDto updateUserDto);
        /*public Task<serviceResponse<List<GetUpdatedUserDto>>> GetAllUsers();*/
        public Task<serviceResponse<List<GetUserDto>>> DeleteUser(int id);
        public Task<serviceResponse<GetUserDto>> GetUserById(int id);


    }
}
