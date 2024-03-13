using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Commands.CreateDieuKhoanBoSungKhacPhuc;

public class CreateDieuKhoanBoSungKhacPhucCommandHandler : IRequestHandler<CreateDieuKhoanBoSungKhacPhucCommand, ApiResult<DieuKhoanBoSungKhacPhucDto>>
{
    private readonly IMapper _mapper;
    private readonly IDieuKhoanBoSungKhacPhucRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateDieuKhoanBoSungKhacPhucCommandHandler";

    public CreateDieuKhoanBoSungKhacPhucCommandHandler(IMapper mapper, IDieuKhoanBoSungKhacPhucRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<DieuKhoanBoSungKhacPhucDto>> Handle(CreateDieuKhoanBoSungKhacPhucCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = _mapper.Map<DieuKhoanBoSungKhacPhuc>(request);

        await _repository.CreateDieuKhoanBoSungKhacPhuc(dkxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<DieuKhoanBoSungKhacPhucDto>(_mapper.Map<DieuKhoanBoSungKhacPhucDto>(dkxp));
    }
}