using FluentValidation;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Common;

public class CreateOrUpdateCommandValidator : AbstractValidator<CreateOrUpdateCommand>
{
    public CreateOrUpdateCommandValidator()
    {
        RuleFor(x => x.DieuKhoanXuPhatId)
           .NotEmpty().WithMessage("{DieuKhoanXuPhatId} is required.")
           .NotNull();

        RuleFor(x => x.Dieu)
           .NotEmpty().WithMessage("{Dieu} is required.")
           .NotNull()
           .MaximumLength(512).WithMessage("{Dieu} must not exceed 512 characters.");

        RuleFor(x => x.Khoan)
           .NotEmpty().WithMessage("{Khoan} is required.")
           .NotNull()
           .MaximumLength(512).WithMessage("{Khoan} must not exceed 512 characters.");

        RuleFor(x => x.Diem)
           .NotEmpty().WithMessage("{Dien} is required.")
           .NotNull()
           .MaximumLength(512).WithMessage("{Diem} must not exceed 512 characters.");
    }
}