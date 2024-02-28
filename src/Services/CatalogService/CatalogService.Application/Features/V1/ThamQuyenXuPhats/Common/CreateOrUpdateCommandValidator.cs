using FluentValidation;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Common;

public class CreateOrUpdateCommandValidator : AbstractValidator<CreateOrUpdateCommand>
{
    public CreateOrUpdateCommandValidator()
    {
        RuleFor(x => x.DieuKhoanXuPhatId)
           .NotEmpty().WithMessage("{DieuKhoanXuPhatId} is required.")
           .NotNull();

        RuleFor(x => x.ThamQuyen)
           .NotEmpty().WithMessage("{ThamQuyen} is required.")
           .NotNull()
           .MaximumLength(512).WithMessage("{ThamQuyen} must not exceed 512 characters.");
    }
}