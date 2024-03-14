using AutoMapper;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.GiayPhepTamGius;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Commands.UpdateGiayPhepTamGiu
{
    public class UpdateGiayPhepTamGiuHandler : IRequestHandler<UpdateGiayPhepTamGiuCommand, ApiResult<GiayPhepTamGiuDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGiayPhepTamGiuRepository _repository;
        private readonly IHoSoXuLyViPhamRepository _hoSoXuLyViPhamRepository;
        private readonly ILogger _logger;
        private const string MethodName = "UpdateGiayPhepTamGiuHandler";

        public UpdateGiayPhepTamGiuHandler(IMapper mapper, IGiayPhepTamGiuRepository repository, ILogger logger, IHoSoXuLyViPhamRepository hoSoXuLyViPhamRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _hoSoXuLyViPhamRepository = hoSoXuLyViPhamRepository;
        }

        public async Task<ApiResult<GiayPhepTamGiuDto>> Handle(UpdateGiayPhepTamGiuCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var updateGiayPhepTamGiu = await _repository.GetByIdAsync(request.Id);
            if (updateGiayPhepTamGiu == null)
            {
                throw new NotFoundException("Quan Huyen not found");
            }

            var hsxlvp = await _hoSoXuLyViPhamRepository.GetByIdAsync(request.HoSoXuLyViPhamId);
            if (hsxlvp == null)
            {
                throw new NotFoundException("Ho So Xu Ly Vi Pham not found");
            }

            updateGiayPhepTamGiu.HoSoXuLyViPhamId = request.HoSoXuLyViPhamId;
            updateGiayPhepTamGiu.Ten = request.Ten;
            updateGiayPhepTamGiu.SoLuong = request.SoLuong;
            updateGiayPhepTamGiu.TinhTrang = request.TinhTrang;
            updateGiayPhepTamGiu.GhiChu = request.GhiChu is not null ? request.GhiChu : updateGiayPhepTamGiu.GhiChu;

            await _repository.UpdateGiayPhepTamGiu(updateGiayPhepTamGiu);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<GiayPhepTamGiuDto>(_mapper.Map<GiayPhepTamGiuDto>(updateGiayPhepTamGiu));
        }
    }
}