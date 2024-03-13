using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class DieuKhoanBoSungKhacPhucConfiguration : IEntityTypeConfiguration<DieuKhoanBoSungKhacPhuc>
{
    public void Configure(EntityTypeBuilder<DieuKhoanBoSungKhacPhuc> builder)
    {
        builder.ToTable(typeof(DieuKhoanBoSungKhacPhuc).Name);
    }
}