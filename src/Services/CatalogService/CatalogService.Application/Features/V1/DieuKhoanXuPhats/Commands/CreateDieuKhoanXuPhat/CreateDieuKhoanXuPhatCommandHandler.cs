using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Commands.CreateDieuKhoanXuPhat;

public class CreateDieuKhoanXuPhatCommandHandler : IRequestHandler<CreateDieuKhoanXuPhatCommand, ApiResult<DieuKhoanXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly IDieuKhoanXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateDieuKhoanXuPhatCommandHandler";

    public CreateDieuKhoanXuPhatCommandHandler(IMapper mapper, IDieuKhoanXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<DieuKhoanXuPhatDto>> Handle(CreateDieuKhoanXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = _mapper.Map<DieuKhoanXuPhat>(request);

        await _repository.CreateDieuKhoanXuPhat(dkxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<DieuKhoanXuPhatDto>(_mapper.Map<DieuKhoanXuPhatDto>(dkxp));
    }
}