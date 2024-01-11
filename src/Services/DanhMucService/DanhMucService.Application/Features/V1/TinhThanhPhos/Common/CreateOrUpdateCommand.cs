using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhos;
using DanhMucService.Application.Parameters.TinhThanhPhos;
using DanhMucService.Domain.Entities;

namespace DanhMucService.Application.Features.V1.TinhThanhPhos.Common
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