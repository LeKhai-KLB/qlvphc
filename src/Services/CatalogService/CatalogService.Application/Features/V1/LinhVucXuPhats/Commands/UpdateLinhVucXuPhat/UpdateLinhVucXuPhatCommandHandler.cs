using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.LinhVucXuPhats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Commands.UpdateLinhVucXuPhat;

public class UpdateLinhVucXuPhatCommandHandler : IRequestHandler<UpdateLinhVucXuPhatCommand, ApiResult<LinhVucXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly ILinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateQuanHuyenHandler";

    public UpdateLinhVucXuPhatCommandHandler(IMapper mapper, ILinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<LinhVucXuPhatDto>> Handle(UpdateLinhVucXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxp = _mapper.Map<LinhVucXuPhat>(request);
        var existLVXP = await _repository.CheckExistLinhVucXuPhat(request.Id);
        if (!existLVXP)
        {
            return new ApiErrorResult<LinhVucXuPhatDto>("Linh vuc xu phat not exists.");
        }
        await _repository.UpdateLinhVucXuPhat(lvxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<LinhVucXuPhatDto>(_mapper.Map<LinhVucXuPhatDto>(lvxp));
    }
}