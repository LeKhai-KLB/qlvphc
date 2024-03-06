using FluentValidation;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Commands.UpdateHinhThucXuPhatChinh;

public class UpdateHinhThucXuPhatChinhCommandValidator : AbstractValidator<UpdateHinhThucXuPhatChinhCommand>
{
    public UpdateHinhThucXuPhatChinhCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");

        RuleFor(x => x.Ten)
          .NotEmpty().WithMessage("{Ten} is required.");
    }
}