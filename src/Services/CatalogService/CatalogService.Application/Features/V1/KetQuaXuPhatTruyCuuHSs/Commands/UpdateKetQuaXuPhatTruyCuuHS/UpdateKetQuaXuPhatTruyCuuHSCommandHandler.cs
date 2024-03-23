using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Commands.UpdateKetQuaXuPhatTruyCuuHS;

public class UpdateKetQuaXuPhatTruyCuuHSCommandHandler : IRequestHandler<UpdateKetQuaXuPhatTruyCuuHSCommand, ApiResult<KetQuaXuPhatTruyCuuHSDto>>
{
    private readonly IMapper _mapper;
    private readonly IKetQuaXuPhatTruyCuuHSRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateKetQuaXuPhatTruyCuuHSCommandHandler";

    public UpdateKetQuaXuPhatTruyCuuHSCommandHandler(IMapper mapper, IKetQuaXuPhatTruyCuuHSRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<KetQuaXuPhatTruyCuuHSDto>> Handle(UpdateKetQuaXuPhatTruyCuuHSCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = _mapper.Map<KetQuaXuPhatTruyCuuHS>(request);
        var existCQBH = await _repository.CheckExistKetQuaXuPhatTruyCuuHS(request.Id);
        if (!existCQBH)
        {
            return new ApiErrorResult<KetQuaXuPhatTruyCuuHSDto>("KetQuaXuPhatTruyCuuHS not exists.");
        }
        await _repository.UpdateKetQuaXuPhatTruyCuuHS(cqbh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<KetQuaXuPhatTruyCuuHSDto>(_mapper.Map<KetQuaXuPhatTruyCuuHSDto>(cqbh));
    }
}