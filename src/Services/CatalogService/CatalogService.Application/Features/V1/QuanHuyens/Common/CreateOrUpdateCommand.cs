using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.QuanHuyens.Common
{
    public class CreateOrUpdateCommand : IMapFrom<QuanHuyen>
    {
        public int TinhThanhPhoId { get; set; }
        public string MaDinhDanh { get; set; }

        public string Ten { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrUpdateCommand, QuanHuyen>();
        }
    }
}