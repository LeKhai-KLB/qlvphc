using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Common
{
    public class CreateOrUpdateCommand : IMapFrom<HinhThucXuPhatBoSung>
    {
        public string Ten { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrUpdateCommand, HinhThucXuPhatBoSung>();
        }
    }
}