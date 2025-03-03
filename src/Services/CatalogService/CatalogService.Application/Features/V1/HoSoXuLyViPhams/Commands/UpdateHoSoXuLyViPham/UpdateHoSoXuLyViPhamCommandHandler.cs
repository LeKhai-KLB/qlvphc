using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Commands.UpdateHoSoXuLyViPham;

public class UpdateHoSoXuLyViPhamCommandHandler : IRequestHandler<UpdateHoSoXuLyViPhamCommand, ApiResult<HoSoXuLyViPhamDto>>
{
    private readonly IMapper _mapper;
    private readonly IHoSoXuLyViPhamRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateHoSoXuLyViPhamHandler";

    public UpdateHoSoXuLyViPhamCommandHandler(IMapper mapper, IHoSoXuLyViPhamRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<HoSoXuLyViPhamDto>> Handle(UpdateHoSoXuLyViPhamCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var hsxlvp = _mapper.Map<HoSoXuLyViPham>(request);
        var hsxlvpDb = await _repository.GetHoSoXuLyViPhamById(request.Id);
        if (hsxlvpDb == null)
        {
            return new ApiErrorResult<HoSoXuLyViPhamDto>("Ho so xu ly vi pham khong ton tai.");
        }

        hsxlvp.HinhAnhViPham = JsonConvert.SerializeObject(request.HinhAnhViPhams);
        
        await _repository.UpdateHoSoXuLyViPham(hsxlvp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HoSoXuLyViPhamDto>(_mapper.Map<HoSoXuLyViPhamDto>(hsxlvp));
    }
}