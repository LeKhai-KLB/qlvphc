using FluentValidation;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Commands.UpdateLoaiVanBan;

public class UpdateLoaiVanBanCommandValidator : AbstractValidator<UpdateLoaiVanBanCommand>
{
    public UpdateLoaiVanBanCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}