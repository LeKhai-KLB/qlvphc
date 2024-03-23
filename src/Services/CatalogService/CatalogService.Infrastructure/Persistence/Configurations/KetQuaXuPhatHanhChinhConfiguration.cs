using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class KetQuaXuPhatHanhChinhConfiguration : IEntityTypeConfiguration<KetQuaXuPhatHanhChinh>
{
    public void Configure(EntityTypeBuilder<KetQuaXuPhatHanhChinh> builder)
    {
        builder.ToTable(typeof(KetQuaXuPhatHanhChinh).Name);
    }
}