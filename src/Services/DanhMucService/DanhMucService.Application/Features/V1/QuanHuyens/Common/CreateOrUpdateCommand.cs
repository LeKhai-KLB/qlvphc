using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Domain.Entities;

namespace DanhMucService.Application.Features.V1.QuanHuyens.Common
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