using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Commands.CreateThamQuyenXuPhat;

public class CreateThamQuyenXuPhatCommandHandler : IRequestHandler<CreateThamQuyenXuPhatCommand, ApiResult<ThamQuyenXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly IThamQuyenXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateThamQuyenXuPhatCommandHandler";

    public CreateThamQuyenXuPhatCommandHandler(IMapper mapper, IThamQuyenXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<ThamQuyenXuPhatDto>> Handle(CreateThamQuyenXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var tqxp = _mapper.Map<ThamQuyenXuPhat>(request);

        await _repository.CreateThamQuyenXuPhat(tqxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ThamQuyenXuPhatDto>(_mapper.Map<ThamQuyenXuPhatDto>(tqxp));
    }
}