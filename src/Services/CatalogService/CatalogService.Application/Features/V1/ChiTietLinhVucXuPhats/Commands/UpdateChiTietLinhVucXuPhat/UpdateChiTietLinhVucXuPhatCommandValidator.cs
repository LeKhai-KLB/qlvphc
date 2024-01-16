using FluentValidation;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Commands.UpdateChiTietLinhVucXuPhat;

public class UpdateChiTietLinhVucXuPhatCommandValidator : AbstractValidator<UpdateChiTietLinhVucXuPhatCommand>
{
    public UpdateChiTietLinhVucXuPhatCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}