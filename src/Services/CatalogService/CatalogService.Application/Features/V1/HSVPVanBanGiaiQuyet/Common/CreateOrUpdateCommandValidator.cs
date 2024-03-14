using FluentValidation;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Common;

public class CreateOrUpdateCommandValidator : AbstractValidator<CreateOrUpdateCommand>
{
    public CreateOrUpdateCommandValidator()
    {
        RuleFor(x => x.HoSoXuLyViPhamId)
           .NotEmpty().WithMessage("{HoSoXuLyViPhamId} is required.")
           .NotNull();

        RuleFor(x => x.VanBanGiaiQuyetId)
           .NotEmpty().WithMessage("{VanBanGiaiQuyetId} is required.")
           .NotNull();

        RuleFor(x => x.NgayNhap)
           .NotEmpty().WithMessage("{NgayNhap} is required.")
           .NotNull();

        RuleFor(x => x.SoQuyetDinh)
           .NotEmpty().WithMessage("{SoQuyetDinh} is required.")
           .NotNull();
    }
}