using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CongDans;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CongDans.Commands.UpdateCongDan;

public class UpdateCongDanCommandHandler : IRequestHandler<UpdateCongDanCommand, ApiResult<CongDanDto>>
{
    private readonly IMapper _mapper;
    private readonly ICongDanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateCongDanCommandHandler";

    public UpdateCongDanCommandHandler(IMapper mapper, ICongDanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<CongDanDto>> Handle(UpdateCongDanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = _mapper.Map<CongDan>(request);
        var existCQBH = await _repository.CheckExistCongDan(request.Id);
        if (!existCQBH)
        {
            return new ApiErrorResult<CongDanDto>("Cong dan not exists.");
        }
        await _repository.UpdateCongDan(cqbh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<CongDanDto>(_mapper.Map<CongDanDto>(cqbh));
    }
}