using AutoMapper;
using IdentityService.API.Models;
using IdentityService.API.Models.UserModels;

namespace IdentityService.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, ResponseManager>();
            CreateMap<RegisterUser, ResponseManager>();
            CreateMap<UpdateUser, ResponseManager>();
        }
    }
}