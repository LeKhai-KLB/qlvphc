using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ChiTietHSXLVPVVBGQs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Commands.UpdateChiTietHSXLVPVVBGQ;

public class UpdateChiTietHSXLVPVVBGQCommandHandler : IRequestHandler<UpdateChiTietHSXLVPVVBGQCommand, ApiResult<ChiTietHSXLVPVVBGQDto>>
{
    private readonly IMapper _mapper;
    private readonly IChiTietHSXLVPVVBGQRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateChiTietHSXLVPVVBGQCommandHandler";

    public UpdateChiTietHSXLVPVVBGQCommandHandler(IMapper mapper, IChiTietHSXLVPVVBGQRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<ChiTietHSXLVPVVBGQDto>> Handle(UpdateChiTietHSXLVPVVBGQCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = _mapper.Map<ChiTietHSXLVPVVBGQ>(request);
        var existCQBH = await _repository.CheckExistChiTietHSXLVPVVBGQ(request.Id);
        if (!existCQBH)
        {
            return new ApiErrorResult<ChiTietHSXLVPVVBGQDto>("Chi tiet HSXLVPVVBGQ not exists.");
        }
        await _repository.UpdateChiTietHSXLVPVVBGQ(cqbh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ChiTietHSXLVPVVBGQDto>(_mapper.Map<ChiTietHSXLVPVVBGQDto>(cqbh));
    }
}