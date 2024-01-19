using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.LoaiVanBans;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Commands.CreateLoaiVanBan;

public class CreateLoaiVanBanCommandHandler : IRequestHandler<CreateLoaiVanBanCommand, ApiResult<LoaiVanBanDto>>
{
    private readonly IMapper _mapper;
    private readonly ILoaiVanBanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateLoaiVanBanCommandHandler";

    public CreateLoaiVanBanCommandHandler(IMapper mapper, ILoaiVanBanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<LoaiVanBanDto>> Handle(CreateLoaiVanBanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvb = _mapper.Map<LoaiVanBan>(request);
        await _repository.CreateLoaiVanBan(lvb);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<LoaiVanBanDto>(_mapper.Map<LoaiVanBanDto>(lvb));
    }
}