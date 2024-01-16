using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.TinhThanhPhos;
using CatalogService.Application.Features.V1.TinhThanhPhos.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using TinhThanhPhoDto = CatalogService.Application.Common.Models.TinhThanhPhos.TinhThanhPhoDto;

namespace CatalogService.Application.Features.V1.TinhThanhPhos.Commands.CreateTinhThanhPho
{
    public class CreateTinhThanhPhoCommand : CreateOrUpdateCommand, IRequest<ApiResult<TinhThanhPhoDto>>, IMapFrom<TinhThanhPho>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTinhThanhPhoDto, CreateTinhThanhPhoCommand>();
            profile.CreateMap<CreateTinhThanhPhoCommand, TinhThanhPho>();
        }
    }
}