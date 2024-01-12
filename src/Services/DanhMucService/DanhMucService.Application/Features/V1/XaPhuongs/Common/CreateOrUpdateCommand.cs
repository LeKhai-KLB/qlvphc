using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Domain.Entities;

namespace DanhMucService.Application.Features.V1.XaPhuongs.Common
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