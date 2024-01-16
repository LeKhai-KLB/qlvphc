using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.LinhVucXuPhats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Commands.CreateLinhVucXuPhat;

public class CreateLinhVucXuPhatCommandHandler : IRequestHandler<CreateLinhVucXuPhatCommand, ApiResult<LinhVucXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly ILinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateLinhVucXuPhatCommandHandler";

    public CreateLinhVucXuPhatCommandHandler(IMapper mapper, ILinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<LinhVucXuPhatDto>> Handle(CreateLinhVucXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxp = _mapper.Map<LinhVucXuPhat>(request);

        var existLVXP = await _repository.CheckExistLinhVucXuPhat(request.TenLinhVuc, request.NhomLinhVuc);
        if (existLVXP)
        {
            return new ApiErrorResult<LinhVucXuPhatDto>("Linh vuc xu phat exists.");
        }

        await _repository.CreateLinhVucXuPhat(lvxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<LinhVucXuPhatDto>(_mapper.Map<LinhVucXuPhatDto>(lvxp));
    }
}