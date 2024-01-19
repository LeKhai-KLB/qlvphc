using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanLienQuans;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Commands.CreateVanBanLienQuan;

public class CreateVanBanLienQuanCommandHandler : IRequestHandler<CreateVanBanLienQuanCommand, ApiResult<VanBanLienQuanDto>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanLienQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateVanBanLienQuanCommandHandler";

    public CreateVanBanLienQuanCommandHandler(IMapper mapper, IVanBanLienQuanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<VanBanLienQuanDto>> Handle(CreateVanBanLienQuanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vblq = _mapper.Map<VanBanLienQuan>(request);
        await _repository.CreateVanBanLienQuan(vblq);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<VanBanLienQuanDto>(_mapper.Map<VanBanLienQuanDto>(vblq));
    }
}