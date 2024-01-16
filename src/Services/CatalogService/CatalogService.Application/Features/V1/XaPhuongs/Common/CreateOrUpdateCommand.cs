using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.XaPhuongs.Common
{
    public class CreateOrUpdateCommand : IMapFrom<XaPhuong>
    {
        public int QuanHuyenId { get; set; }
        public string MaDinhDanh { get; set; }

        public string Ten { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrUpdateCommand, XaPhuong>();
        }
    }
}