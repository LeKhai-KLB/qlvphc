using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetAllDieuKhoanXuPhats;

public class GetAllDieuKhoanXuPhatsQueryHandler : IRequestHandler<GetAllDieuKhoanXuPhatsQuery, ApiResult<IEnumerable<DieuKhoanXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IDieuKhoanXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllDieuKhoanXuPhatQueryHandler";

    public GetAllDieuKhoanXuPhatsQueryHandler(IMapper mapper, IDieuKhoanXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<DieuKhoanXuPhatDto>>> Handle(GetAllDieuKhoanXuPhatsQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxpEntities = await _repository.GetAllDieuKhoanXuPhats();
        var lvxpDto = _mapper.Map<IEnumerable<DieuKhoanXuPhatDto>>(lvxpEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<DieuKhoanXuPhatDto>>(lvxpDto);
    }
}