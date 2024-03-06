using FluentValidation;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Commands.UpdateHinhThucXuPhatBoSung;

public class UpdateHinhThucXuPhatBoSungCommandValidator : AbstractValidator<UpdateHinhThucXuPhatBoSungCommand>
{
    public UpdateHinhThucXuPhatBoSungCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");

        RuleFor(x => x.Ten)
          .NotEmpty().WithMessage("{Ten} is required.");
    }
}