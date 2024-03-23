using AutoMapper;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Commands.ImportHVVPFromQD;

public class ImportHVVPFromQDCommandHandler : IRequestHandler<ImportHVVPFromQDCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IHanhViViPhamRepository _repository;
    private readonly IHoSoXuLyViPhamRepository _hsvpRepository;
    private readonly IQuyetDinhXuPhatRepository _qdxpRepository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateHanhViViPhamHandler";

    public ImportHVVPFromQDCommandHandler(IMapper mapper, IHanhViViPhamRepository repository, IHoSoXuLyViPhamRepository hsvpRepository, IQuyetDinhXuPhatRepository qdxpRepository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _hsvpRepository = hsvpRepository ?? throw new ArgumentNullException(nameof(hsvpRepository));
        _qdxpRepository = qdxpRepository ?? throw new ArgumentNullException(nameof(qdxpRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(ImportHVVPFromQDCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var hsvp = await _hsvpRepository.GetHoSoXuLyViPhamById(request.HoSoXuLyViPhamId);
        if (hsvp == null) throw new NotFoundException("Ho so xu ly vi pham not exists.", request.HoSoXuLyViPhamId);

        var qdxps = await _qdxpRepository.GetQuyetDinhXuPhatByHoSoXuLyViPhamId(request.HoSoXuLyViPhamId);
        if (qdxps.Any())
        {
            var hsvpHanhVis = await _repository.GeByQuyetDinhXuPhatIds(qdxps.Select(x => x.Id).ToList());
            if (hsvpHanhVis.Any())
            {
                foreach(var hv in hsvpHanhVis)
                {
                    hv.HoSoXuLyViPhamId = request.HoSoXuLyViPhamId;                    
                }
                await _repository.UpdateListAsync(hsvpHanhVis);
            }
        }

        _logger.Information($"END: {MethodName}");

        return true;
    }
}