using FluentValidation;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Commands.UpdateVanBanPhapLuat;

public class UpdateVanBanPhapLuatCommandValidator : AbstractValidator<UpdateVanBanPhapLuatCommand>
{
    public UpdateVanBanPhapLuatCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}