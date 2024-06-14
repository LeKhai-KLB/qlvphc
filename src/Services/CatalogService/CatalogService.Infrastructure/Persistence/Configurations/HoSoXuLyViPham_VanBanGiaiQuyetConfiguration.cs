using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class HoSoXuLyViPham_VanBanGiaiQuyetConfiguration : IEntityTypeConfiguration<HoSoXuLyViPham_VanBanGiaiQuyet>
{
    public void Configure(EntityTypeBuilder<HoSoXuLyViPham_VanBanGiaiQuyet> builder)
    {
        builder.ToTable(typeof(HoSoXuLyViPham_VanBanGiaiQuyet).Name);

        builder.HasAlternateKey(c => new { c.HoSoXuLyViPhamId, c.VanBanGiaiQuyetId})
            .HasName("AlternateKey_HoSoXuLyViPham_VanBanGiaiQuyet");
    }
}