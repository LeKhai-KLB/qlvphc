using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class TangVatPhuongTienTamGiuConfiguration : IEntityTypeConfiguration<TangVatPhuongTienTamGiu>
{
    public void Configure(EntityTypeBuilder<TangVatPhuongTienTamGiu> builder)
    {
        builder.ToTable(typeof(TangVatPhuongTienTamGiu).Name);
    }
}