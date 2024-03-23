using FluentValidation;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Commands.UpdateKetQuaXuPhatTruyCuuHS;

public class UpdateKetQuaXuPhatTruyCuuHSCommandValidator : AbstractValidator<UpdateKetQuaXuPhatTruyCuuHSCommand>
{
    public UpdateKetQuaXuPhatTruyCuuHSCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}