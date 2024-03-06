using FluentValidation;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Commands.UpdateQuyetDinhXuPhat;

public class UpdateQuyetDinhXuPhatCommandValidator : AbstractValidator<UpdateQuyetDinhXuPhatCommand>
{
    public UpdateQuyetDinhXuPhatCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}