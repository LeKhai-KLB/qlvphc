using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class LoaiVanBanConfiguration : IEntityTypeConfiguration<LoaiVanBan>
{
    public void Configure(EntityTypeBuilder<LoaiVanBan> builder)
    {
        builder.ToTable(typeof(LoaiVanBan).Name);
    }
}