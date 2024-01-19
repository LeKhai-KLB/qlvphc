﻿using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanLienQuans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Queries.GetVanBanLienQuanByVanBanPhapLuatId;

public class GetVanBanLienQuanByVanBanPhapLuatIdQueryHandler : IRequestHandler<GetVanBanLienQuanByVanBanPhapLuatIdQuery, ApiResult<IEnumerable<VanBanLienQuanDto>>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanLienQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetVanBanLienQuanByVanBanPhapLuatIdQueryHandler";

    public GetVanBanLienQuanByVanBanPhapLuatIdQueryHandler(IMapper mapper, IVanBanLienQuanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<VanBanLienQuanDto>>> Handle(GetVanBanLienQuanByVanBanPhapLuatIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vblqEntities = await _repository.GetVanBanLienQuanByVanBanPhapLuatId(request.VanBanPhapLuatId);
        var vblqDto = _mapper.Map<IEnumerable<VanBanLienQuanDto>>(vblqEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<VanBanLienQuanDto>>(vblqDto);
    }
}