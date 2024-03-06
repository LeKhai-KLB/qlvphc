using FluentValidation;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Common
{
    public class CreateOrUpdateCommandValidator : AbstractValidator<CreateOrUpdateCommand>
    {
        public CreateOrUpdateCommandValidator()
        {
            RuleFor(x => x.Ten)
               .NotEmpty().WithMessage("{Ten} is required.")
               .NotNull()
               .MaximumLength(255).WithMessage("{Ten} must not exceed 255 characters.");
        }
    }
}