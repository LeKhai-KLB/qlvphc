using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanLienQuans;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Commands.UpdateVanBanLienQuan;

public class UpdateVanBanLienQuanCommandHandler : IRequestHandler<UpdateVanBanLienQuanCommand, ApiResult<VanBanLienQuanDto>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanLienQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateVanBanLienQuanCommandHandler";

    public UpdateVanBanLienQuanCommandHandler(IMapper mapper, IVanBanLienQuanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<VanBanLienQuanDto>> Handle(UpdateVanBanLienQuanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vblq = _mapper.Map<VanBanLienQuan>(request);
        var existVBLQ = await _repository.CheckExistVanBanLienQuan(request.Id);
        if (!existVBLQ)
        {
            return new ApiErrorResult<VanBanLienQuanDto>("Van ban lien quan not exists.");
        }
        await _repository.UpdateVanBanLienQuan(vblq);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<VanBanLienQuanDto>(_mapper.Map<VanBanLienQuanDto>(vblq));
    }
}