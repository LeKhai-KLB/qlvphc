using FluentValidation;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Commands.UpdateDieuKhoanBoSungKhacPhuc;

public class UpdateDieuKhoanBoSungKhacPhucCommandValidator : AbstractValidator<UpdateDieuKhoanBoSungKhacPhucCommand>
{
    public UpdateDieuKhoanBoSungKhacPhucCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}