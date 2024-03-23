using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Commands.CreateKetQuaXuPhatTruyCuuHS;

public class CreateKetQuaXuPhatTruyCuuHSCommandHandler : IRequestHandler<CreateKetQuaXuPhatTruyCuuHSCommand, ApiResult<KetQuaXuPhatTruyCuuHSDto>>
{
    private readonly IMapper _mapper;
    private readonly IKetQuaXuPhatTruyCuuHSRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateKetQuaXuPhatTruyCuuHSCommandHandler";

    public CreateKetQuaXuPhatTruyCuuHSCommandHandler(IMapper mapper, IKetQuaXuPhatTruyCuuHSRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<KetQuaXuPhatTruyCuuHSDto>> Handle(CreateKetQuaXuPhatTruyCuuHSCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = _mapper.Map<KetQuaXuPhatTruyCuuHS>(request);
        await _repository.CreateKetQuaXuPhatTruyCuuHS(cqbh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<KetQuaXuPhatTruyCuuHSDto>(_mapper.Map<KetQuaXuPhatTruyCuuHSDto>(cqbh));
    }
}