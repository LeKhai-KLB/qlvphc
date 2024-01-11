using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Application.Common.Models.QuanHuyens;
using DanhMucService.Application.Features.V1.QuanHuyens.Common;
using DanhMucService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace DanhMucService.Application.Features.V1.QuanHuyens.Commands.UpdateQuanHuyen;

public class UpdateQuanHuyenCommand : CreateOrUpdateCommand, IRequest<ApiResult<QuanHuyenDto>>, IMapFrom<QuanHuyen>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateQuanHuyenCommand, QuanHuyen>()
            .IgnoreAllNonExisting();
    }
}