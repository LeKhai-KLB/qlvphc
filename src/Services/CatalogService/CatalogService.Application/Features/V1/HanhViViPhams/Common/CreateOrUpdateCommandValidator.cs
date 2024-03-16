using FluentValidation;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Common;

public class CreateOrUpdateCommandValidator : AbstractValidator<CreateOrUpdateCommand>
{
    public CreateOrUpdateCommandValidator()
    {
        RuleFor(x => x.DieuKhoanXuPhatId)
           .NotEmpty().WithMessage("{DieuKhoanXuPhatId} is required.")
           .NotNull();

        RuleFor(x => x.LinhVucXuPhatId)
           .NotEmpty().WithMessage("{LinhVucXuPhatId} is required.")
           .NotNull();

        RuleFor(x => x.MucPhat)
           .NotEmpty().WithMessage("{MucPhat} is required.")
           .NotNull();
    }
}