using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HanhViViPhams;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Commands.CreateHanhViViPham;

public class CreateHanhViViPhamCommandHandler : IRequestHandler<CreateHanhViViPhamCommand, ApiResult<HanhViViPhamDto>>
{
    private readonly IMapper _mapper;
    private readonly IHanhViViPhamRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateHanhViViPhamCommandHandler";

    public CreateHanhViViPhamCommandHandler(IMapper mapper, IHanhViViPhamRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<HanhViViPhamDto>> Handle(CreateHanhViViPhamCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = _mapper.Map<HanhViViPham>(request);

        await _repository.CreateHanhViViPham(dkxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HanhViViPhamDto>(_mapper.Map<HanhViViPhamDto>(dkxp));
    }
}