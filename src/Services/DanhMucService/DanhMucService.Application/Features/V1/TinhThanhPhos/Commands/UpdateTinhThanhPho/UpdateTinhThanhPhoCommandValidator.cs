using FluentValidation;

namespace DanhMucService.Application.Features.V1.TinhThanhPhos.Commands.UpdateTinhThanhPho;

public class UpdateTinhThanhPhoCommandValidator : AbstractValidator<UpdateTinhThanhPhoCommand>
{
    public UpdateTinhThanhPhoCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}