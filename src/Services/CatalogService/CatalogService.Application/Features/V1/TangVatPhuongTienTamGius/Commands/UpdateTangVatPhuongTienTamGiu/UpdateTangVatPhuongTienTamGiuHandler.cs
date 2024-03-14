using AutoMapper;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.TangVatPhuongTienTamGius;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Commands.UpdateTangVatPhuongTienTamGiu
{
    public class UpdateTangVatPhuongTienTamGiuHandler : IRequestHandler<UpdateTangVatPhuongTienTamGiuCommand, ApiResult<TangVatPhuongTienTamGiuDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITangVatPhuongTienTamGiuRepository _repository;
        private readonly IHoSoXuLyViPhamRepository _hoSoXuLyViPhamRepository;
        private readonly ILogger _logger;
        private const string MethodName = "UpdateTangVatPhuongTienTamGiuHandler";

        public UpdateTangVatPhuongTienTamGiuHandler(IMapper mapper, ITangVatPhuongTienTamGiuRepository repository, ILogger logger, IHoSoXuLyViPhamRepository hoSoXuLyViPhamRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _hoSoXuLyViPhamRepository = hoSoXuLyViPhamRepository;
        }

        public async Task<ApiResult<TangVatPhuongTienTamGiuDto>> Handle(UpdateTangVatPhuongTienTamGiuCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var updateTangVatPhuongTienTamGiu = await _repository.GetByIdAsync(request.Id);
            if (updateTangVatPhuongTienTamGiu == null)
            {
                throw new NotFoundException("Quan Huyen not found");
            }

            var hsxlvp = await _hoSoXuLyViPhamRepository.GetByIdAsync(request.HoSoXuLyViPhamId);
            if (hsxlvp == null)
            {
                throw new NotFoundException("Ho So Xu Ly Vi Pham not found");
            }

            updateTangVatPhuongTienTamGiu.HoSoXuLyViPhamId = request.HoSoXuLyViPhamId;
            updateTangVatPhuongTienTamGiu.Ten = request.Ten;
            updateTangVatPhuongTienTamGiu.DonViTinh = request.DonViTinh;
            updateTangVatPhuongTienTamGiu.SoLuong = request.SoLuong;
            updateTangVatPhuongTienTamGiu.ChungLoai = request.ChungLoai;
            updateTangVatPhuongTienTamGiu.TinhTrang = request.TinhTrang;
            updateTangVatPhuongTienTamGiu.GhiChu = request.GhiChu is not null ? request.GhiChu : updateTangVatPhuongTienTamGiu.GhiChu;

            await _repository.UpdateTangVatPhuongTienTamGiu(updateTangVatPhuongTienTamGiu);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<TangVatPhuongTienTamGiuDto>(_mapper.Map<TangVatPhuongTienTamGiuDto>(updateTangVatPhuongTienTamGiu));
        }
    }
}