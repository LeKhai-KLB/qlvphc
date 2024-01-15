using AutoMapper;
using IdentityService.Application.Common.Models;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Common.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, ResponseManager>();
        }
    }
}