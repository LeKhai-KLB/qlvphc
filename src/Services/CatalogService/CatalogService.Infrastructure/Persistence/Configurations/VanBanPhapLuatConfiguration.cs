using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class VanBanPhapLuatConfiguration : IEntityTypeConfiguration<VanBanPhapLuat>
{
    public void Configure(EntityTypeBuilder<VanBanPhapLuat> builder)
    {
        builder.ToTable(typeof(VanBanPhapLuat).Name);

        builder.Property(e => e.NgayBanHanh)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.NgayHieuLuc)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
    }
}