using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanGiaiQuyets;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Commands.UpdateVanBanGiaiQuyet;

public class UpdateVanBanGiaiQuyetCommandHandler : IRequestHandler<UpdateVanBanGiaiQuyetCommand, ApiResult<VanBanGiaiQuyetDto>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateVanBanGiaiQuyetCommandHandler";

    public UpdateVanBanGiaiQuyetCommandHandler(IMapper mapper, IVanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<VanBanGiaiQuyetDto>> Handle(UpdateVanBanGiaiQuyetCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vbgq = _mapper.Map<VanBanGiaiQuyet>(request);
        var existVBGQ = await _repository.CheckExistVanBanGiaiQuyet(request.MaGiayTo);
        if (!existVBGQ)
        {
            return new ApiErrorResult<VanBanGiaiQuyetDto>("Van ban giai quyet not exists.");
        }
        await _repository.UpdateVanBanGiaiQuyet(vbgq);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<VanBanGiaiQuyetDto>(_mapper.Map<VanBanGiaiQuyetDto>(vbgq));
    }
}