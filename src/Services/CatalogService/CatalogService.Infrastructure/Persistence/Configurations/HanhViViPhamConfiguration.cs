using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class HanhViViPhamConfiguration : IEntityTypeConfiguration<HanhViViPham>
{
    public void Configure(EntityTypeBuilder<HanhViViPham> builder)
    {
        builder.ToTable(typeof(HanhViViPham).Name);
    }
}