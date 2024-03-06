using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class ChiTietQuyetDinhXuPhatConfiguration : IEntityTypeConfiguration<ChiTietQuyetDinhXuPhat>
{
    public void Configure(EntityTypeBuilder<ChiTietQuyetDinhXuPhat> builder)
    {
        builder.ToTable(typeof(ChiTietQuyetDinhXuPhat).Name);
    }
}