using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Commands.UpdateThamQuyenXuPhat;

public class UpdateThamQuyenXuPhatCommandHandler : IRequestHandler<UpdateThamQuyenXuPhatCommand, ApiResult<ThamQuyenXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly IThamQuyenXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateThamQuyenXuPhatHandler";

    public UpdateThamQuyenXuPhatCommandHandler(IMapper mapper, IThamQuyenXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<ThamQuyenXuPhatDto>> Handle(UpdateThamQuyenXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var tqxp = _mapper.Map<ThamQuyenXuPhat>(request);
        var tqxpDb = await _repository.GetThamQuyenXuPhatById(request.Id);
        if (tqxpDb == null)
        {
            return new ApiErrorResult<ThamQuyenXuPhatDto>("Tham quyen xu phat not exists.");
        }

        await _repository.UpdateThamQuyenXuPhat(tqxpDb);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ThamQuyenXuPhatDto>(_mapper.Map<ThamQuyenXuPhatDto>(tqxp));
    }
}