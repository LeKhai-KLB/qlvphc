using FluentValidation;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Commands.UpdateHanhViViPham;

public class UpdateHanhViViPhamCommandValidator : AbstractValidator<UpdateHanhViViPhamCommand>
{
    public UpdateHanhViViPhamCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}