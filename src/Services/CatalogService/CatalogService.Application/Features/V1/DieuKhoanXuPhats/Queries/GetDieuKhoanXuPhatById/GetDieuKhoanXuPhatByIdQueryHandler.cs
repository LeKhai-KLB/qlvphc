using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetDieuKhoanXuPhatById;

public class GetDieuKhoanXuPhatByIdQueryHandler : IRequestHandler<GetDieuKhoanXuPhatByIdQuery, ApiResult<DieuKhoanXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly IDieuKhoanXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetDieuKhoanXuPhatByIdQueryHandler";

    public GetDieuKhoanXuPhatByIdQueryHandler(IMapper mapper, IDieuKhoanXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<DieuKhoanXuPhatDto>> Handle(GetDieuKhoanXuPhatByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxpEntity = await _repository.GetDieuKhoanXuPhatById(request.Id);
        var dkxpDto = _mapper.Map<DieuKhoanXuPhatDto>(dkxpEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<DieuKhoanXuPhatDto>(dkxpDto);
    }
}