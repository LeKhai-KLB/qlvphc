using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Commands.CreateKetQuaXuPhatHanhChinh;

public class CreateKetQuaXuPhatHanhChinhCommandHandler : IRequestHandler<CreateKetQuaXuPhatHanhChinhCommand, ApiResult<KetQuaXuPhatHanhChinhDto>>
{
    private readonly IMapper _mapper;
    private readonly IKetQuaXuPhatHanhChinhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateKetQuaXuPhatHanhChinhCommandHandler";

    public CreateKetQuaXuPhatHanhChinhCommandHandler(IMapper mapper, IKetQuaXuPhatHanhChinhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<KetQuaXuPhatHanhChinhDto>> Handle(CreateKetQuaXuPhatHanhChinhCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = _mapper.Map<KetQuaXuPhatHanhChinh>(request);
        await _repository.CreateKetQuaXuPhatHanhChinh(cqbh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<KetQuaXuPhatHanhChinhDto>(_mapper.Map<KetQuaXuPhatHanhChinhDto>(cqbh));
    }
}