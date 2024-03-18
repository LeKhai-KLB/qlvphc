using FluentValidation;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Commands.UpdateChiTietHSXLVPVVBGQ;

public class UpdateChiTietHSXLVPVVBGQCommandValidator : AbstractValidator<UpdateChiTietHSXLVPVVBGQCommand>
{
    public UpdateChiTietHSXLVPVVBGQCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}