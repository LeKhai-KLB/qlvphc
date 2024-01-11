using FluentValidation;

namespace DanhMucService.Application.Features.V1.QuanHuyens.Common
{
    public class CreateOrUpdateCommandValidator : AbstractValidator<CreateOrUpdateCommand>
    {
        public CreateOrUpdateCommandValidator()
        {
            RuleFor(x => x.Ten)
               .NotEmpty().WithMessage("{Ten} is required.")
               .NotNull()
               .MaximumLength(255).WithMessage("{Ten} must not exceed 255 characters.");

            RuleFor(x => x.MaDinhDanh)
               .NotEmpty().WithMessage("{MaDinhDanh} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{MaDinhDanh} must not exceed 255 characters.");
        }
    }
}