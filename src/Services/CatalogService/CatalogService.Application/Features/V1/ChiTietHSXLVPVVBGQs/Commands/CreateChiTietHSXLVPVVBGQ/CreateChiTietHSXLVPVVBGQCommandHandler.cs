using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ChiTietHSXLVPVVBGQs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Commands.CreateChiTietHSXLVPVVBGQ;

public class CreateChiTietHSXLVPVVBGQCommandHandler : IRequestHandler<CreateChiTietHSXLVPVVBGQCommand, ApiResult<ChiTietHSXLVPVVBGQDto>>
{
    private readonly IMapper _mapper;
    private readonly IChiTietHSXLVPVVBGQRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateChiTietHSXLVPVVBGQCommandHandler";

    public CreateChiTietHSXLVPVVBGQCommandHandler(IMapper mapper, IChiTietHSXLVPVVBGQRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<ChiTietHSXLVPVVBGQDto>> Handle(CreateChiTietHSXLVPVVBGQCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var chiTietHSXLVPVVBGQ = _mapper.Map<ChiTietHSXLVPVVBGQ>(request);
        await _repository.CreateChiTietHSXLVPVVBGQ(chiTietHSXLVPVVBGQ);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ChiTietHSXLVPVVBGQDto>(_mapper.Map<ChiTietHSXLVPVVBGQDto>(chiTietHSXLVPVVBGQ));
    }
}