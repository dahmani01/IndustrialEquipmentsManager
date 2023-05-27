using AutoMapper;
using CPG_Platform.Dtos.MachineDtos;
using CPG_Platform.Dtos.Service;
using CPG_Platform.Dtos.User;
using CPG_Platform.Models;

namespace CPG_Platform
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Service, GetServiceDto>();
            CreateMap<Machine, GetMachineDto>();
            CreateMap<UpdateMachineDto, Machine>();
            CreateMap<AddNewMachineDto, Machine>();
            CreateMap<User, GetUpdatedUserDto>();
            CreateMap<User, GetUserDto>();
        }
    }
}
