using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ChiTietHSXLVPVVBGQs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Queries.GetChiTietHSXLVPVVBGQById;

public class GetChiTietHSXLVPVVBGQByIdQueryHandler : IRequestHandler<GetChiTietHSXLVPVVBGQByIdQuery, ApiResult<ChiTietHSXLVPVVBGQDto>>
{
    private readonly IMapper _mapper;
    private readonly IChiTietHSXLVPVVBGQRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetChiTietHSXLVPVVBGQByIdQueryHandler";

    public GetChiTietHSXLVPVVBGQByIdQueryHandler(IMapper mapper, IChiTietHSXLVPVVBGQRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<ChiTietHSXLVPVVBGQDto>> Handle(GetChiTietHSXLVPVVBGQByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntity = await _repository.GetChiTietHSXLVPVVBGQById(request.Id);
        var cqbhDto = _mapper.Map<ChiTietHSXLVPVVBGQDto>(cqbhEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ChiTietHSXLVPVVBGQDto>(cqbhDto);
    }
}