using FluentValidation;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Common;

internal class CreateOrUpdateCommandValidator : AbstractValidator<CreateOrUpdateCommand>
{
    public CreateOrUpdateCommandValidator()
    {
        RuleFor(x => x.NgayNhap)
           .NotEmpty().WithMessage("{NgayNhap} is required.")
           .NotNull();

        RuleFor(x => x.SoBB)
           .NotEmpty().WithMessage("{SoBB} is required.")
           .NotNull()
           .MaximumLength(512).WithMessage("{SoBB} must not exceed 512 characters.");
    }
}