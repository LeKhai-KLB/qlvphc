using FluentValidation;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Commands.UpdateKetQuaXuPhatHanhChinh;

public class UpdateKetQuaXuPhatHanhChinhCommandValidator : AbstractValidator<UpdateKetQuaXuPhatHanhChinhCommand>
{
    public UpdateKetQuaXuPhatHanhChinhCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}