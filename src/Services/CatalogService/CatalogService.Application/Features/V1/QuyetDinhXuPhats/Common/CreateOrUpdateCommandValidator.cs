using FluentValidation;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Common
{
    public class CreateOrUpdateCommandValidator : AbstractValidator<CreateOrUpdateCommand>
    {
        public CreateOrUpdateCommandValidator()
        {
            RuleFor(x => x.HoSoXuLyViPhamId)
               .NotEmpty().WithMessage("{HoSoXuLyViPhamId} is required.")
               .NotNull()
               .GreaterThan(0).WithMessage("{HoSoXuLyViPhamId} must greater than zero.");

            // TODO check nhung field con lai

        }
    }
}