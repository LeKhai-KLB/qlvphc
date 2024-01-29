using FluentValidation;

namespace IdentityService.Application.Features.V1.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Username)
           .NotEmpty().WithMessage("{Username} is required.")
           .NotNull()
           .MaximumLength(50).WithMessage("{Username} must not exceed 50 characters.");

        RuleFor(x => x.Email)
           .EmailAddress()
           .MaximumLength(255).WithMessage("{Email} must not exceed 255 characters.");

        RuleFor(x => x.Password)
           .NotEmpty().WithMessage("{Password} is required.")
           .NotNull()
           .MaximumLength(50).WithMessage("{Password} must not exceed 50 characters.")
           .MinimumLength(8).WithMessage("{Password} must equal or longer than 8 characters.");

        RuleFor(x => x.ConfirmPassword)
           .NotEmpty().WithMessage("{ConfirmPassword} is required.")
           .NotNull()
           .MaximumLength(50).WithMessage("{ConfirmPassword} must not exceed 50 characters.")
           .MinimumLength(8).WithMessage("{ConfirmPassword} must equal or longer than 8 characters.");

        RuleFor(x => x.PhoneNumber)
           .MaximumLength(255).WithMessage("{PhoneNumber} must not exceed 255 characters.");

        RuleFor(x => x.Role)
           .NotEmpty().WithMessage("{Role} is required.")
           .NotNull()
           .MaximumLength(255).WithMessage("{Role} must not exceed 255 characters.");

        RuleFor(x => x.HoTen)
           .NotEmpty().WithMessage("Ho ten is required.")
           .NotNull()
           .MaximumLength(255).WithMessage("Ho ten must not exceed 255 characters.");

        RuleFor(x => x.NgaySinh)
           .NotEmpty().WithMessage("Ngay sinh is required.")
           .NotNull();

        RuleFor(x => x.CCCD)
           .NotEmpty().WithMessage("CCCD is required.")
           .NotNull()
           .MaximumLength(255).WithMessage("CCCD must not exceed 255 characters.");

        RuleFor(x => x.GioiTinh)
           .NotEmpty().WithMessage("Gioi tinh is required.")
           .NotNull();

        RuleFor(x => x.DiaChi)
           .NotEmpty().WithMessage("Dia chi is required.")
           .NotNull()
           .MaximumLength(4000).WithMessage("Dia chi must not exceed 4000 characters.");

        RuleFor(x => x.GhiChu)
           .MaximumLength(4000).WithMessage("Ghi chu must not exceed 4000 characters.");
    }
}