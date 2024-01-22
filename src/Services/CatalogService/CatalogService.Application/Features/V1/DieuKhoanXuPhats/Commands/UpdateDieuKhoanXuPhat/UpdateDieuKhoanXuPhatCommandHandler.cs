using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Commands.UpdateDieuKhoanXuPhat;

public class UpdateDieuKhoanXuPhatCommandHandler : IRequestHandler<UpdateDieuKhoanXuPhatCommand, ApiResult<DieuKhoanXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly IDieuKhoanXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateDieuKhoanXuPhatHandler";

    public UpdateDieuKhoanXuPhatCommandHandler(IMapper mapper, IDieuKhoanXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<DieuKhoanXuPhatDto>> Handle(UpdateDieuKhoanXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = _mapper.Map<DieuKhoanXuPhat>(request);
        var dkxpDb = await _repository.GetDieuKhoanXuPhatById(request.Id);
        if (dkxpDb == null)
        {
            return new ApiErrorResult<DieuKhoanXuPhatDto>("Dieu khoan xu phat not exists.");
        }


        dkxpDb.LinhVucXuPhatId = dkxp.LinhVucXuPhatId;
        dkxpDb.Dieu = dkxp.Dieu;
        dkxpDb.Diem = dkxp.Diem;
        dkxpDb.Khoan = dkxp.Khoan;
        await _repository.UpdateDieuKhoanXuPhat(dkxpDb);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<DieuKhoanXuPhatDto>(_mapper.Map<DieuKhoanXuPhatDto>(dkxp));
    }
}