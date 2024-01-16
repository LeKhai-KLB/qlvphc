using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhos;
using CatalogService.Application.Parameters.TinhThanhPhos;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.TinhThanhPhos.Common
{
    public class CreateOrUpdateCommand : IMapFrom<TinhThanhPho>
    {
        public string MaDinhDanh { get; set; }

        public string Ten { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrUpdateCommand, TinhThanhPho>();
            profile.CreateMap<GetTinhThanhPhosQuery, TinhThanhPhoParameter>();
        }
    }
}