using FluentValidation;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Commands.UpdateVanBanLienQuan;

public class UpdateVanBanLienQuanCommandValidator : AbstractValidator<UpdateVanBanLienQuanCommand>
{
    public UpdateVanBanLienQuanCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}