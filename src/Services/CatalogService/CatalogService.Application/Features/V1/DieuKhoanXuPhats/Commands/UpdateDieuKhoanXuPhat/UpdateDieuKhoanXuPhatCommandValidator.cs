using FluentValidation;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Commands.UpdateDieuKhoanXuPhat;

public class UpdateDieuKhoanXuPhatCommandValidator : AbstractValidator<UpdateDieuKhoanXuPhatCommand>
{
    public UpdateDieuKhoanXuPhatCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}