using AutoMapper;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Commands.UpdateQuyetDinhXuPhat
{
    public class UpdateQuyetDinhXuPhatHandler : IRequestHandler<UpdateQuyetDinhXuPhatCommand, ApiResult<QuyetDinhXuPhatDto>>
    {
        private readonly IMapper _mapper;
        private readonly IQuyetDinhXuPhatRepository _repository;
        private readonly IHoSoXuLyViPhamRepository _hoSoXuLyViPhamRepository;
        private readonly ILogger _logger;
        private const string MethodName = "UpdateQuyetDinhXuPhatHandler";

        public UpdateQuyetDinhXuPhatHandler(IMapper mapper, IQuyetDinhXuPhatRepository repository, ILogger logger, IHoSoXuLyViPhamRepository hoSoXuLyViPhamRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _hoSoXuLyViPhamRepository = hoSoXuLyViPhamRepository;
        }

        public async Task<ApiResult<QuyetDinhXuPhatDto>> Handle(UpdateQuyetDinhXuPhatCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var updateQuyetDinhXuPhat = await _repository.GetByIdAsync(request.Id);
            if (updateQuyetDinhXuPhat == null)
            {
                throw new NotFoundException("Quan Huyen not found");
            }

            var hsxlvp = await _hoSoXuLyViPhamRepository.GetByIdAsync(request.HoSoXuLyViPhamId);
            if (hsxlvp == null)
            {
                throw new NotFoundException("Ho So Xu Ly Vi Pham not found");
            }

            updateQuyetDinhXuPhat.NgayNhapQuyetDinh = request.NgayNhapQuyetDinh;
            updateQuyetDinhXuPhat.SoQuyetDinh = request.SoQuyetDinh;
            updateQuyetDinhXuPhat.NgayQuyetDinh = request.NgayQuyetDinh;
            updateQuyetDinhXuPhat.HieuLucThiHanhNgay = request.HieuLucThiHanhNgay;
            updateQuyetDinhXuPhat.CoQuanBanHanhId = request.CoQuanBanHanhId;
            updateQuyetDinhXuPhat.NguoiRaQuyetDinhId = request.NguoiRaQuyetDinhId;
            updateQuyetDinhXuPhat.LoaiDoiTuongViPham = request.LoaiDoiTuongViPham;
            updateQuyetDinhXuPhat.DoiTuongViPhamId = request.DoiTuongViPhamId;
            updateQuyetDinhXuPhat.DoiTuongViPhamKhac = request.DoiTuongViPhamKhac ?? updateQuyetDinhXuPhat.DoiTuongViPhamKhac;
            updateQuyetDinhXuPhat.CanCuVanBan = request.CanCuVanBan;
            updateQuyetDinhXuPhat.CanCuQuyDinh = request.CanCuQuyDinh;
            updateQuyetDinhXuPhat.SoTienPhat = request.SoTienPhat ?? updateQuyetDinhXuPhat.SoTienPhat;
            updateQuyetDinhXuPhat.SoTienPhatBangChu = request.SoTienPhatBangChu ?? updateQuyetDinhXuPhat.SoTienPhatBangChu;
            updateQuyetDinhXuPhat.TienKhacPhuc = request.TienKhacPhuc ?? updateQuyetDinhXuPhat.TienKhacPhuc;
            updateQuyetDinhXuPhat.NoiThucHien = request.NoiThucHien ?? updateQuyetDinhXuPhat.NoiThucHien;
            updateQuyetDinhXuPhat.TienTruyThu = request.TienTruyThu ?? updateQuyetDinhXuPhat.TienTruyThu;
            updateQuyetDinhXuPhat.ThoiHanKhacPhucHauQua = request.ThoiHanKhacPhucHauQua ?? updateQuyetDinhXuPhat.ThoiHanKhacPhucHauQua;
            updateQuyetDinhXuPhat.ThoiHanThucHienXuPhatBoSung = request.ThoiHanThucHienXuPhatBoSung ?? updateQuyetDinhXuPhat.ThoiHanThucHienXuPhatBoSung;
            updateQuyetDinhXuPhat.NoiNopTienPhat = request.NoiNopTienPhat;
            updateQuyetDinhXuPhat.NoiNopTienPhatTuNhap = request.NoiNopTienPhatTuNhap ?? updateQuyetDinhXuPhat.NoiNopTienPhatTuNhap;
            updateQuyetDinhXuPhat.DiaDiemViPham = request.DiaDiemViPham;
            updateQuyetDinhXuPhat.HinhThucXuPhatChinh = request.HinhThucXuPhatChinh;
            updateQuyetDinhXuPhat.TinhTietTangNang = request.TinhTietTangNang ?? updateQuyetDinhXuPhat.TinhTietTangNang;
            updateQuyetDinhXuPhat.TinhTietGiamNhe = request.TinhTietGiamNhe ?? updateQuyetDinhXuPhat.TinhTietGiamNhe;
            updateQuyetDinhXuPhat.HinhThucXuPhatCuThe = request.HinhThucXuPhatCuThe;
            updateQuyetDinhXuPhat.HinhThucXuPhatBoSung = request.HinhThucXuPhatBoSung ?? updateQuyetDinhXuPhat.HinhThucXuPhatBoSung;
            updateQuyetDinhXuPhat.HinhThucXuPhatBoSungCuThe = request.HinhThucXuPhatBoSungCuThe ?? updateQuyetDinhXuPhat.HinhThucXuPhatBoSungCuThe;
            updateQuyetDinhXuPhat.BienPhapKhacPhucHauQua = request.BienPhapKhacPhucHauQua;
            updateQuyetDinhXuPhat.BienPhapKhacPhucHauQuaCuThe = request.BienPhapKhacPhucHauQuaCuThe ?? updateQuyetDinhXuPhat.BienPhapKhacPhucHauQuaCuThe;
            updateQuyetDinhXuPhat.NoiDungLienQuanKhacPhucHauQua = request.NoiDungLienQuanKhacPhucHauQua ?? updateQuyetDinhXuPhat.NoiDungLienQuanKhacPhucHauQua;
            updateQuyetDinhXuPhat.DonViPhoiHopThucHien = request.DonViPhoiHopThucHien;
            updateQuyetDinhXuPhat.NoiNhan = request.NoiNhan;

            await _repository.UpdateQuyetDinhXuPhat(updateQuyetDinhXuPhat);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<QuyetDinhXuPhatDto>(_mapper.Map<QuyetDinhXuPhatDto>(updateQuyetDinhXuPhat));
        }
    }
}