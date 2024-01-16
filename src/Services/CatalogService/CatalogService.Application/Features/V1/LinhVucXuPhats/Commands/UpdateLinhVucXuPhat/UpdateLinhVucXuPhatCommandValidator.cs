using FluentValidation;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Commands.UpdateLinhVucXuPhat;

public class UpdateLinhVucXuPhatCommandValidator : AbstractValidator<UpdateLinhVucXuPhatCommand>
{
    public UpdateLinhVucXuPhatCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}