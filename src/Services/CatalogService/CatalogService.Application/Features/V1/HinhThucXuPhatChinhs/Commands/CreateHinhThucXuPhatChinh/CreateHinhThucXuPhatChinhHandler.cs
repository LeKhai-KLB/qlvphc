using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HinhThucXuPhatChinhs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Commands.CreateHinhThucXuPhatChinh;

public class CreateHinhThucXuPhatChinhHandler : IRequestHandler<CreateHinhThucXuPhatChinhCommand, ApiResult<HinhThucXuPhatChinhDto>>
{
    private readonly IMapper _mapper;
    private readonly IHinhThucXuPhatChinhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateHinhThucXuPhatChinhHandler";

    public CreateHinhThucXuPhatChinhHandler(IMapper mapper, IHinhThucXuPhatChinhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<HinhThucXuPhatChinhDto>> Handle(CreateHinhThucXuPhatChinhCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var hinhThucXuPhatChinh = _mapper.Map<HinhThucXuPhatChinh>(request);

        await _repository.CreateHinhThucXuPhatChinh(hinhThucXuPhatChinh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HinhThucXuPhatChinhDto>(_mapper.Map<HinhThucXuPhatChinhDto>(hinhThucXuPhatChinh));
    }
}