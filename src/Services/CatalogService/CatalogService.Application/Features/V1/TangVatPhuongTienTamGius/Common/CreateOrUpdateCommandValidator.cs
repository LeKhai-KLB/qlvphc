using FluentValidation;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Common
{
    public class CreateOrUpdateCommandValidator : AbstractValidator<CreateOrUpdateCommand>
    {
        public CreateOrUpdateCommandValidator()
        {
            RuleFor(x => x.HoSoXuLyViPhamId)
               .NotEmpty().WithMessage("{HoSoXuLyViPhamId} is required.")
               .NotNull()
               .GreaterThan(0).WithMessage("{HoSoXuLyViPhamId} must greater than zero.");

            RuleFor(x => x.Ten)
               .NotEmpty().WithMessage("{Ten} is required.")
               .NotNull()
               .MaximumLength(255).WithMessage("{Ten} must not exceed 255 characters.");

            RuleFor(x => x.DonViTinh)
               .NotEmpty().WithMessage("{DonViTinh} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{DonViTinh} must not exceed 50 characters.");

            RuleFor(x => x.SoLuong)
               .NotEmpty().WithMessage("{SoLuong} is required.")
               .NotNull()
               .GreaterThan(0).WithMessage("{SoLuong} must greater than zero.");
            
            RuleFor(x => x.ChungLoai)
               .NotEmpty().WithMessage("{ChungLoai} is required.")
               .NotNull()
               .MaximumLength(255).WithMessage("{ChungLoai} must not exceed 255 characters.");

            RuleFor(x => x.TinhTrang)
               .NotEmpty().WithMessage("{TinhTrang} is required.")
               .NotNull()
               .MaximumLength(255).WithMessage("{TinhTrang} must not exceed 255 characters.");

        }
    }
}