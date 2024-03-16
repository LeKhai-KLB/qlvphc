using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HanhViViPhams;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Commands.UpdateHanhViViPham;

public class UpdateHanhViViPhamCommandHandler : IRequestHandler<UpdateHanhViViPhamCommand, ApiResult<HanhViViPhamDto>>
{
    private readonly IMapper _mapper;
    private readonly IHanhViViPhamRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateHanhViViPhamHandler";

    public UpdateHanhViViPhamCommandHandler(IMapper mapper, IHanhViViPhamRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<HanhViViPhamDto>> Handle(UpdateHanhViViPhamCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = _mapper.Map<HanhViViPham>(request);
        var dkxpDb = await _repository.GetHanhViViPhamById(request.Id);
        if (dkxpDb == null)
        {
            return new ApiErrorResult<HanhViViPhamDto>("Hanh vi vi pham not exists.");
        }

        await _repository.UpdateHanhViViPham(dkxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HanhViViPhamDto>(_mapper.Map<HanhViViPhamDto>(dkxp));
    }
}