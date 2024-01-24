using FluentValidation;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Commands.UpdateVanBanGiaiQuyet;

public class UpdateVanBanGiaiQuyetCommandValidator : AbstractValidator<UpdateVanBanGiaiQuyetCommand>
{
    public UpdateVanBanGiaiQuyetCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}