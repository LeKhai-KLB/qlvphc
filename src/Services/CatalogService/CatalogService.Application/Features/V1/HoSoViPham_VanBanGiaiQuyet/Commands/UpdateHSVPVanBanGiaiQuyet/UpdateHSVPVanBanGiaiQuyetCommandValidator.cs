﻿using FluentValidation;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.UpdateHSVPVanBanGiaiQuyet;

public class UpdateHSVPVanBanGiaiQuyetCommandValidator : AbstractValidator<UpdateHoSoXuLyViPham_VanBanGiaiQuyetCommand>
{
    public UpdateHSVPVanBanGiaiQuyetCommandValidator()
    {
        RuleFor(x => x.HoSoXuLyViPhamId)
          .NotEmpty().WithMessage("{HoSoXuLyViPhamId} is required.");

        RuleFor(x => x.VanBanGiaiQuyetId)
          .NotEmpty().WithMessage("{VanBanGiaiQuyetId} is required.");
    }
}