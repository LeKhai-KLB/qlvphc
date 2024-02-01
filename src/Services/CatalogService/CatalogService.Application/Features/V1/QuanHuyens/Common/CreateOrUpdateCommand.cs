using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.QuanHuyens.Queries.GetQuanHuyens;
using CatalogService.Application.Parameters.QuanHuyens;
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
            profile.CreateMap<GetQuanHuyensQuery, QuanHuyenParameter>();
        }
    }
}