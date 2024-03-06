using FluentValidation;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Commands.UpdateGiayPhepTamGiu;

public class UpdateGiayPhepTamGiuCommandValidator : AbstractValidator<UpdateGiayPhepTamGiuCommand>
{
    public UpdateGiayPhepTamGiuCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}