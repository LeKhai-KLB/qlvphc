using FluentValidation;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Common;

public class CreateOrUpdateCommandValidator : AbstractValidator<CreateOrUpdateCommand>
{
    public CreateOrUpdateCommandValidator()
    {
        RuleFor(x => x.SoHoSo)
           .NotEmpty().WithMessage("{SoHoSo} is required.")
           .NotNull();

        RuleFor(x => x.TenHoSo)
           .NotEmpty().WithMessage("{TenHoSo} is required.")
           .NotNull()
           .MaximumLength(512).WithMessage("{Dieu} must not exceed 512 characters.");

        RuleFor(x => x.NgayHoSo)
           .NotEmpty().WithMessage("{NgayHoSo} is required.")
           .NotNull();

        RuleFor(x => x.CaNhanViPhamId)
           .NotEmpty().WithMessage("{CaNhanViPhamId} is required.")
           .NotNull();

        RuleFor(x => x.IsCaNhanViPhamKhac)
           .NotEmpty().WithMessage("{IsCaNhanViPhamKhac} is required.")
           .NotNull();

        RuleFor(x => x.TrangThaiHoSoViPham)
          .NotEmpty().WithMessage("{TrangThaiHoSoViPham} is required.")
          .NotNull();

        RuleFor(x => x.TinhTietViPham)
          .NotEmpty().WithMessage("{TinhTietViPham} is required.")
          .NotNull();

        RuleFor(x => x.LoaiVuViecViPham)
          .NotEmpty().WithMessage("{LoaiVuViecViPham} is required.")
          .NotNull();
    }
}