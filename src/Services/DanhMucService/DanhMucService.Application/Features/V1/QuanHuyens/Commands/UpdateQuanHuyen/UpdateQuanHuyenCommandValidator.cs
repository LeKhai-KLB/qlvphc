using FluentValidation;

namespace DanhMucService.Application.Features.V1.QuanHuyens.Commands.UpdateQuanHuyen;

public class UpdateQuanHuyenCommandValidator : AbstractValidator<UpdateQuanHuyenCommand>
{
    public UpdateQuanHuyenCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}