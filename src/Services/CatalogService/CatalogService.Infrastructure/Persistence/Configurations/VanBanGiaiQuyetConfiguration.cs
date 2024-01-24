using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class VanBanGiaiQuyetConfiguration : IEntityTypeConfiguration<VanBanGiaiQuyet>
{
    public void Configure(EntityTypeBuilder<VanBanGiaiQuyet> builder)
    {
        builder.ToTable(typeof(VanBanGiaiQuyet).Name);
    }
}