using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Commands.CreateQuyetDinhXuPhat;

public class CreateQuyetDinhXuPhatHandler : IRequestHandler<CreateQuyetDinhXuPhatCommand, ApiResult<QuyetDinhXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly IQuyetDinhXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateQuyetDinhXuPhatHandler";

    public CreateQuyetDinhXuPhatHandler(IMapper mapper, IQuyetDinhXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<QuyetDinhXuPhatDto>> Handle(CreateQuyetDinhXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var quyetDinhXuPhat = _mapper.Map<QuyetDinhXuPhat>(request);

        await _repository.CreateQuyetDinhXuPhat(quyetDinhXuPhat);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<QuyetDinhXuPhatDto>(_mapper.Map<QuyetDinhXuPhatDto>(quyetDinhXuPhat));
    }
}