using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Commands.CreateHinhThucXuPhatBoSung;

public class CreateHinhThucXuPhatBoSungHandler : IRequestHandler<CreateHinhThucXuPhatBoSungCommand, ApiResult<HinhThucXuPhatBoSungDto>>
{
    private readonly IMapper _mapper;
    private readonly IHinhThucXuPhatBoSungRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateHinhThucXuPhatBoSungHandler";

    public CreateHinhThucXuPhatBoSungHandler(IMapper mapper, IHinhThucXuPhatBoSungRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<HinhThucXuPhatBoSungDto>> Handle(CreateHinhThucXuPhatBoSungCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var hinhThucXuPhatBoSung = _mapper.Map<HinhThucXuPhatBoSung>(request);

        await _repository.CreateHinhThucXuPhatBoSung(hinhThucXuPhatBoSung);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HinhThucXuPhatBoSungDto>(_mapper.Map<HinhThucXuPhatBoSungDto>(hinhThucXuPhatBoSung));
    }
}