﻿using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using MediatR;
using Newtonsoft.Json;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Queries.GetHoSoXuLyViPhamById;

public class GetHoSoXuLyViPhamByIdQueryHandler : IRequestHandler<GetHoSoXuLyViPhamByIdQuery, ApiResult<HoSoXuLyViPhamDto>>
{
    private readonly IMapper _mapper;
    private readonly IHoSoXuLyViPhamRepository _repository;
    private readonly IHoSoXuLyViPham_VanBanGiaiQuyetRepository _hSXLVP_VBGQRepository;
    private readonly ILogger _logger;
    private const string MethodName = "GetHoSoXuLyViPhamByIdQueryHandler";

    public GetHoSoXuLyViPhamByIdQueryHandler(IMapper mapper, IHoSoXuLyViPhamRepository repository, ILogger logger, IHoSoXuLyViPham_VanBanGiaiQuyetRepository hSXLVP_VBGQRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
        _hSXLVP_VBGQRepository = hSXLVP_VBGQRepository;
    }

    public async Task<ApiResult<HoSoXuLyViPhamDto>> Handle(GetHoSoXuLyViPhamByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var hsxlvpEntity = await _repository.GetHoSoXuLyViPhamById(request.Id);
        var hsxlvpDto = _mapper.Map<HoSoXuLyViPhamDto>(hsxlvpEntity);
        hsxlvpDto.HinhAnhViPhams = !string.IsNullOrEmpty(hsxlvpEntity.HinhAnhViPham) ? JsonConvert.DeserializeObject<List<string>>(hsxlvpEntity.HinhAnhViPham) : null;

        var hsxlvp_vbgps = await _hSXLVP_VBGQRepository.GetHoSoXuLyViPham_VanBanGiaiQuyetsByHoSoXuLyViPhamId(hsxlvpDto.Id);
        hsxlvpDto.VanBanGiaiQuyetIds = hsxlvp_vbgps.Select(x => x.VanBanGiaiQuyetId).ToList();

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HoSoXuLyViPhamDto>(hsxlvpDto);
    }
}