using AutoMapper;
using Entity.Models;
using Bussiness.Dtos;

namespace Bussiness.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}