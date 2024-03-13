using FluentValidation;

namespace CatalogService.Application.Features.V1.CongDans.Commands.UpdateCongDan;

public class UpdateCongDanCommandValidator : AbstractValidator<UpdateCongDanCommand>
{
    public UpdateCongDanCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}