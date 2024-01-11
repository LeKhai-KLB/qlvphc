using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Application.Common.Models.TinhThanhPhos;
using DanhMucService.Application.Features.V1.TinhThanhPhos.Common;
using DanhMucService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace DanhMucService.Application.Features.V1.TinhThanhPhos.Commands.UpdateTinhThanhPho;

public class UpdateTinhThanhPhoCommand : CreateOrUpdateCommand, IRequest<ApiResult<TinhThanhPhoDto>>, IMapFrom<TinhThanhPho>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateTinhThanhPhoCommand, TinhThanhPho>()
            .IgnoreAllNonExisting();
    }
}