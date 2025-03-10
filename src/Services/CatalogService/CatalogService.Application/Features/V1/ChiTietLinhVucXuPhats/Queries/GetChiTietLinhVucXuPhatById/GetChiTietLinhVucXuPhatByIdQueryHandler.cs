﻿using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Queries.GetChiTietLinhVucXuPhatById;

public class GetChiTietLinhVucXuPhatByIdQueryHandler : IRequestHandler<GetChiTietLinhVucXuPhatByIdQuery, ApiResult<ChiTietLinhVucXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly IChiTietLinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetChiTietLinhVucXuPhatByIdQueryHandler";

    public GetChiTietLinhVucXuPhatByIdQueryHandler(IMapper mapper, IChiTietLinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<ChiTietLinhVucXuPhatDto>> Handle(GetChiTietLinhVucXuPhatByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxpEntity = await _repository.GetChiTietLinhVucXuPhatById(request.Id);
        var lvxpDto = _mapper.Map<ChiTietLinhVucXuPhatDto>(lvxpEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ChiTietLinhVucXuPhatDto>(lvxpDto);
    }
}