using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Commands.UpdateCoQuanBanHanh;

public class UpdateCoQuanBanHanhCommandHandler : IRequestHandler<UpdateCoQuanBanHanhCommand, ApiResult<CoQuanBanHanhDto>>
{
    private readonly IMapper _mapper;
    private readonly ICoQuanBanHanhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateCoQuanBanHanhCommandHandler";

    public UpdateCoQuanBanHanhCommandHandler(IMapper mapper, ICoQuanBanHanhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<CoQuanBanHanhDto>> Handle(UpdateCoQuanBanHanhCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = _mapper.Map<CoQuanBanHanh>(request);
        var existCQBH = await _repository.CheckExistCoQuanBanHanh(request.Id);
        if (!existCQBH)
        {
            return new ApiErrorResult<CoQuanBanHanhDto>("Co quan ban hanh not exists.");
        }
        await _repository.UpdateCoQuanBanHanh(cqbh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<CoQuanBanHanhDto>(_mapper.Map<CoQuanBanHanhDto>(cqbh));
    }
}