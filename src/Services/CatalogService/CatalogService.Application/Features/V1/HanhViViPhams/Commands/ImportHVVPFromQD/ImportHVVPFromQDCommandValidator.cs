using FluentValidation;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Commands.ImportHVVPFromQD;

public class ImportHVVPFromQDCommandValidator : AbstractValidator<ImportHVVPFromQDCommand>
{
    public ImportHVVPFromQDCommandValidator()
    {
        RuleFor(x => x.HoSoXuLyViPhamId)
          .NotEmpty().WithMessage("{HoSoXuLyViPhamId} is required.");
    }
}