using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CoQuans;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuans.Commands.UpdateCoQuan;

public class UpdateCoQuanCommandHandler : IRequestHandler<UpdateCoQuanCommand, ApiResult<CoQuanDto>>
{
    private readonly IMapper _mapper;
    private readonly ICoQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateCoQuanCommandHandler";

    public UpdateCoQuanCommandHandler(IMapper mapper, ICoQuanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<CoQuanDto>> Handle(UpdateCoQuanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = _mapper.Map<CoQuan>(request);
        var existCQBH = await _repository.CheckExistCoQuan(request.Id);
        if (!existCQBH)
        {
            return new ApiErrorResult<CoQuanDto>("Co quan not exists.");
        }
        await _repository.UpdateCoQuan(cqbh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<CoQuanDto>(_mapper.Map<CoQuanDto>(cqbh));
    }
}