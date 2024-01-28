using FluentValidation;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Commands.UpdateDanhMucDinhDanh;

public class UpdateDanhMucDinhDanhCommandValidator : AbstractValidator<UpdateDanhMucDinhDanhCommand>
{
    public UpdateDanhMucDinhDanhCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{Id} is required.");
    }
}