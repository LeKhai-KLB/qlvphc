using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ToChucs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ToChucs.Commands.UpdateToChuc;

public class UpdateToChucCommandHandler : IRequestHandler<UpdateToChucCommand, ApiResult<ToChucDto>>
{
    private readonly IMapper _mapper;
    private readonly IToChucRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateToChucCommandHandler";

    public UpdateToChucCommandHandler(IMapper mapper, IToChucRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<ToChucDto>> Handle(UpdateToChucCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = _mapper.Map<ToChuc>(request);
        var existCQBH = await _repository.CheckExistToChuc(request.Id);
        if (!existCQBH)
        {
            return new ApiErrorResult<ToChucDto>("To Chuc not exists.");
        }
        await _repository.UpdateToChuc(cqbh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ToChucDto>(_mapper.Map<ToChucDto>(cqbh));
    }
}