using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using CatalogService.Application.Parameters.QuyetDinhXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Queries.GetQuyetDinhXuPhats
{
    public class GetQuyetDinhXuPhatsQueryHandler : IRequestHandler<GetQuyetDinhXuPhatsQuery, PagedResponse<IEnumerable<QuyetDinhXuPhatDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IQuyetDinhXuPhatRepository _repository;
        private readonly IUserServiceClient _userServiceClient;
        private readonly ILogger _logger;
        private const string MethodName = "GetQuyetDinhXuPhatQueryHandler";

        public GetQuyetDinhXuPhatsQueryHandler(IMapper mapper, IQuyetDinhXuPhatRepository repository, IUserServiceClient userServiceClient, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _userServiceClient = userServiceClient ?? throw new ArgumentNullException(nameof(userServiceClient));
            _logger = logger;
        }

        public async Task<PagedResponse<IEnumerable<QuyetDinhXuPhatDto>>> Handle(GetQuyetDinhXuPhatsQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var validFilter = _mapper.Map<QuyetDinhXuPhatParameter>(request);
            var quyetDinhXuPhatPageList = await _repository.GetPagedQuyetDinhXuPhatAsync(validFilter);
            var metaData = quyetDinhXuPhatPageList.GetMetaData();

            var quyetDinhXuPhatDtos = _mapper.Map<List<QuyetDinhXuPhatDto>>(quyetDinhXuPhatPageList);
            if (quyetDinhXuPhatDtos.Any())
            {
                foreach (var quyetDinh in quyetDinhXuPhatDtos)
                {
                    try
                    {
                        var userDto = await _userServiceClient.GetUserAsync(quyetDinh.NguoiRaQuyetDinhId);
                        if (userDto != null)
                        {
                            quyetDinh.NguoiRaQuyetDinh = userDto;
                        }
                    }
                    catch
                    { }
                }
            }

            _logger.Information($"END: {MethodName}");

            return new PagedResponse<IEnumerable<QuyetDinhXuPhatDto>>(quyetDinhXuPhatDtos, metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
        }
    }
}