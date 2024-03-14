using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Queries.GetQuyetDinhXuPhatByHoSoXuLyViPhamId;

public class GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQueryHandler : IRequestHandler<GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQuery, ApiResult<IEnumerable<QuyetDinhXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IQuyetDinhXuPhatRepository _repository;
    private readonly IUserServiceClient _userServiceClient;
    private readonly ILogger _logger;
    private const string MethodName = "GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQueryHandler";

    public GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQueryHandler(IMapper mapper, IQuyetDinhXuPhatRepository repository, IUserServiceClient userServiceClient, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _userServiceClient = userServiceClient ?? throw new ArgumentNullException(nameof(userServiceClient));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<QuyetDinhXuPhatDto>>> Handle(GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var quyetDinhXuPhatEntities = await _repository.GetQuyetDinhXuPhatByHoSoXuLyViPhamId(request.Id);
        var quyetDinhXuPhatDtos = _mapper.Map<IEnumerable<QuyetDinhXuPhatDto>>(quyetDinhXuPhatEntities);

        if (quyetDinhXuPhatDtos.Any())
        {
            foreach(var quyetDinh in quyetDinhXuPhatDtos)
            {
                var userDto = await _userServiceClient.GetUserAsync(quyetDinh.NguoiRaQuyetDinhId);
                if (userDto != null)
                {
                    quyetDinh.NguoiRaQuyetDinh = userDto;
                }
            }
        }

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<QuyetDinhXuPhatDto>>(quyetDinhXuPhatDtos);
    }
}