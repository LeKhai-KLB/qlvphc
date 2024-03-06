using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.GiayPhepTamGius;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Commands.CreateGiayPhepTamGiu;

public class CreateGiayPhepTamGiuHandler : IRequestHandler<CreateGiayPhepTamGiuCommand, ApiResult<GiayPhepTamGiuDto>>
{
    private readonly IMapper _mapper;
    private readonly IGiayPhepTamGiuRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateGiayPhepTamGiuHandler";

    public CreateGiayPhepTamGiuHandler(IMapper mapper, IGiayPhepTamGiuRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<GiayPhepTamGiuDto>> Handle(CreateGiayPhepTamGiuCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var giayPhepTamGiu = _mapper.Map<GiayPhepTamGiu>(request);

        await _repository.CreateGiayPhepTamGiu(giayPhepTamGiu);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<GiayPhepTamGiuDto>(_mapper.Map<GiayPhepTamGiuDto>(giayPhepTamGiu));
    }
}