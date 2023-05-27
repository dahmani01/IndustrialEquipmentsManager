using AutoMapper;
using CPG_Platform.Data;
using CPG_Platform.Dtos.User;
using Microsoft.EntityFrameworkCore;

namespace CPG_Platform.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<serviceResponse<GetUpdatedUserDto>> UpdateUser(UpdateUserDto updateUserDto)
        {
            var response = new serviceResponse<GetUpdatedUserDto>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updateUserDto.Id);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not Found.";
                return response;
            }

            user.isVerified = updateUserDto.isVerified;
            user.Role = updateUserDto.Role;

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetUpdatedUserDto>(user);
            return response;

        }

        //Delete user service
        public async Task<serviceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var response = new serviceResponse<List<GetUserDto>>();
            try
            {
                var user = await _context.Users.FirstAsync(x => x.Id == id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                response.Data = (_context.Users.Select(x => _mapper.Map<GetUserDto>(x))).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        //Get user with id
        public async Task<serviceResponse<GetUserDto>> GetUserById(int id)
        {
            var response = new serviceResponse<GetUserDto>();
            var user = await _context.Users
                .Include(x => x.Secteur)
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    Matricule = u.Matricule,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SectorId = u.Secteur.SecteurId,
                })
               .FirstOrDefaultAsync(u => u.Id == id);




            response.Data = user;

            return response;
        }

    }
}
