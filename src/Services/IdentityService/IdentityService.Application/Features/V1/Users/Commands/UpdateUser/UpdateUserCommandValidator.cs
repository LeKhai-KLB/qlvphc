using FluentValidation;

namespace IdentityService.Application.Features.V1.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("{Id} is required.")
           .NotNull();

        RuleFor(x => x.Username)
           .NotEmpty().WithMessage("{Username} is required.")
           .NotNull()
           .MaximumLength(50).WithMessage("{Username} must not exceed 50 characters.");

        RuleFor(x => x.Email)
           .EmailAddress()
           .MaximumLength(255).WithMessage("{Email} must not exceed 255 characters.");

        RuleFor(x => x.PhoneNumber)
           .MaximumLength(255).WithMessage("{PhoneNumber} must not exceed 255 characters.");
    }
}