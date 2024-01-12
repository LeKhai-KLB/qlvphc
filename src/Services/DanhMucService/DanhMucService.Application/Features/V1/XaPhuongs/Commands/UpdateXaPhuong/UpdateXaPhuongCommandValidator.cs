using FluentValidation;

namespace DanhMucService.Application.Features.V1.XaPhuongs.Commands.UpdateXaPhuong;

public class UpdateXaPhuongCommandValidator : AbstractValidator<UpdateXaPhuongCommand>
{
    public UpdateXaPhuongCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}