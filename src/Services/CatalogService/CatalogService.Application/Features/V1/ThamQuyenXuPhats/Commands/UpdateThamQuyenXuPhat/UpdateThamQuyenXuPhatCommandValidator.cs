using FluentValidation;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Commands.UpdateThamQuyenXuPhat;

public class UpdateThamQuyenXuPhatCommandValidator : AbstractValidator<UpdateThamQuyenXuPhatCommand>
{
    public UpdateThamQuyenXuPhatCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}