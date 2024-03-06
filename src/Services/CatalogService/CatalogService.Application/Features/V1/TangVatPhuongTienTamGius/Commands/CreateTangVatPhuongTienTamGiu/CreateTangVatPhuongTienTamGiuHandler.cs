using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.TangVatPhuongTienTamGius;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Commands.CreateTangVatPhuongTienTamGiu;

public class CreateTangVatPhuongTienTamGiuHandler : IRequestHandler<CreateTangVatPhuongTienTamGiuCommand, ApiResult<TangVatPhuongTienTamGiuDto>>
{
    private readonly IMapper _mapper;
    private readonly ITangVatPhuongTienTamGiuRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateTangVatPhuongTienTamGiuHandler";

    public CreateTangVatPhuongTienTamGiuHandler(IMapper mapper, ITangVatPhuongTienTamGiuRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<TangVatPhuongTienTamGiuDto>> Handle(CreateTangVatPhuongTienTamGiuCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var tangVatPhuongTienTamGiu = _mapper.Map<TangVatPhuongTienTamGiu>(request);

        await _repository.CreateTangVatPhuongTienTamGiu(tangVatPhuongTienTamGiu);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<TangVatPhuongTienTamGiuDto>(_mapper.Map<TangVatPhuongTienTamGiuDto>(tangVatPhuongTienTamGiu));
    }
}