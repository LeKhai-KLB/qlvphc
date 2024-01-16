using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Commands.UpdateChiTietLinhVucXuPhat;

public class UpdateChiTietLinhVucXuPhatCommandHandler : IRequestHandler<UpdateChiTietLinhVucXuPhatCommand, ApiResult<ChiTietLinhVucXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly IChiTietLinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateChiTietLinhVucXuPhatCommandHandler";

    public UpdateChiTietLinhVucXuPhatCommandHandler(IMapper mapper, IChiTietLinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<ChiTietLinhVucXuPhatDto>> Handle(UpdateChiTietLinhVucXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var chiTietLvxp = _mapper.Map<ChiTietLinhVucXuPhat>(request);
        var existChiTietLVXP = await _repository.CheckExistChiTietLinhVucXuPhat(request.Id);
        if (!existChiTietLVXP)
        {
            return new ApiErrorResult<ChiTietLinhVucXuPhatDto>("Chi Tiet Linh vuc xu phat not exists.");
        }
        await _repository.UpdateChiTietLinhVucXuPhat(chiTietLvxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ChiTietLinhVucXuPhatDto>(_mapper.Map<ChiTietLinhVucXuPhatDto>(chiTietLvxp));
    }
}