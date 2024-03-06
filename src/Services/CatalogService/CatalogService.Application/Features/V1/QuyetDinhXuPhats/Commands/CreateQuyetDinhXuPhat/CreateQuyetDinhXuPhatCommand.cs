using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using CatalogService.Application.Features.V1.QuyetDinhXuPhats.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using QuyetDinhXuPhatDto = CatalogService.Application.Common.Models.QuyetDinhXuPhats.QuyetDinhXuPhatDto;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Commands.CreateQuyetDinhXuPhat
{
    public class CreateQuyetDinhXuPhatCommand : CreateOrUpdateCommand, IRequest<ApiResult<QuyetDinhXuPhatDto>>, IMapFrom<QuyetDinhXuPhat>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateQuyetDinhXuPhatDto, CreateQuyetDinhXuPhatCommand>();
            profile.CreateMap<CreateQuyetDinhXuPhatCommand, QuyetDinhXuPhat>();
        }
    }
}