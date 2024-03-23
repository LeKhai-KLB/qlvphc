using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class KetQuaXuPhatTruyCuuHSConfiguration : IEntityTypeConfiguration<KetQuaXuPhatTruyCuuHS>
{
    public void Configure(EntityTypeBuilder<KetQuaXuPhatTruyCuuHS> builder)
    {
        builder.ToTable(typeof(KetQuaXuPhatTruyCuuHS).Name);
    }
}