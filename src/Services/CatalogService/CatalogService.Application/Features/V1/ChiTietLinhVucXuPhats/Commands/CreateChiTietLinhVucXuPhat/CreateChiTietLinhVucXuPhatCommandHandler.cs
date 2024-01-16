using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Commands.CreateChiTietLinhVucXuPhat;

public class CreateChiTietLinhVucXuPhatCommandHandler : IRequestHandler<CreateChiTietLinhVucXuPhatCommand, ApiResult<ChiTietLinhVucXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly IChiTietLinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateChiTietLinhVucXuPhatCommandHandler";

    public CreateChiTietLinhVucXuPhatCommandHandler(IMapper mapper, IChiTietLinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<ChiTietLinhVucXuPhatDto>> Handle(CreateChiTietLinhVucXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var chiTietLvxp = _mapper.Map<ChiTietLinhVucXuPhat>(request);
        await _repository.CreateChiTietLinhVucXuPhat(chiTietLvxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ChiTietLinhVucXuPhatDto>(_mapper.Map<ChiTietLinhVucXuPhatDto>(chiTietLvxp));
    }
}