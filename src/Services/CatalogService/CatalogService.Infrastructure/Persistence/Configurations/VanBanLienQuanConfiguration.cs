using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class VanBanLienQuanConfiguration : IEntityTypeConfiguration<VanBanLienQuan>
{
    public void Configure(EntityTypeBuilder<VanBanLienQuan> builder)
    {
        builder.ToTable(typeof(VanBanLienQuan).Name);

        builder.Property(e => e.NgayBanHanh)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
    }
}