using FluentValidation;

namespace CatalogService.Application.Features.V1.CoQuans.Commands.UpdateCoQuan;

public class UpdateCoQuanCommandValidator : AbstractValidator<UpdateCoQuanCommand>
{
    public UpdateCoQuanCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}