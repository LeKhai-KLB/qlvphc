using FluentValidation;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Commands.UpdateTangVatPhuongTienTamGiu;

public class UpdateTangVatPhuongTienTamGiuCommandValidator : AbstractValidator<UpdateTangVatPhuongTienTamGiuCommand>
{
    public UpdateTangVatPhuongTienTamGiuCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}