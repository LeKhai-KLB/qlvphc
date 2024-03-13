using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CoQuans;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuans.Commands.CreateCoQuan;

public class CreateCoQuanCommandHandler : IRequestHandler<CreateCoQuanCommand, ApiResult<CoQuanDto>>
{
    private readonly IMapper _mapper;
    private readonly ICoQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateCoQuanCommandHandler";

    public CreateCoQuanCommandHandler(IMapper mapper, ICoQuanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<CoQuanDto>> Handle(CreateCoQuanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = _mapper.Map<CoQuan>(request);
        await _repository.CreateCoQuan(cqbh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<CoQuanDto>(_mapper.Map<CoQuanDto>(cqbh));
    }
}