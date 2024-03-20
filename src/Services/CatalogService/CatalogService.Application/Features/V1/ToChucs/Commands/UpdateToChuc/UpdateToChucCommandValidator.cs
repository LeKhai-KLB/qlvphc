using FluentValidation;

namespace CatalogService.Application.Features.V1.ToChucs.Commands.UpdateToChuc;

public class UpdateToChucCommandValidator : AbstractValidator<UpdateToChucCommand>
{
    public UpdateToChucCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}