using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CongDans;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CongDans.Commands.CreateCongDan;

public class CreateCongDanCommandHandler : IRequestHandler<CreateCongDanCommand, ApiResult<CongDanDto>>
{
    private readonly IMapper _mapper;
    private readonly ICongDanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateCongDanCommandHandler";

    public CreateCongDanCommandHandler(IMapper mapper, ICongDanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<CongDanDto>> Handle(CreateCongDanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = _mapper.Map<CongDan>(request);
        await _repository.CreateCongDan(cqbh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<CongDanDto>(_mapper.Map<CongDanDto>(cqbh));
    }
}