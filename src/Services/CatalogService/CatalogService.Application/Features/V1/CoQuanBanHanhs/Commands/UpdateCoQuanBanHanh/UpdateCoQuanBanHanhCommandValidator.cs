using FluentValidation;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Commands.UpdateCoQuanBanHanh;

public class UpdateCoQuanBanHanhCommandValidator : AbstractValidator<UpdateCoQuanBanHanhCommand>
{
    public UpdateCoQuanBanHanhCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}