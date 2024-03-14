using FluentValidation;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Commands.UpdateHoSoXuLyViPham;

public class UpdateHoSoXuLyViPhamCommandValidator : AbstractValidator<UpdateHoSoXuLyViPhamCommand>
{
    public UpdateHoSoXuLyViPhamCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}