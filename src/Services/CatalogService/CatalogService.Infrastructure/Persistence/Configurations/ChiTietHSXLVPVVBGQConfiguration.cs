using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class ChiTietHSXLVPVVBGQConfiguration : IEntityTypeConfiguration<ChiTietHSXLVPVVBGQ>
{
    public void Configure(EntityTypeBuilder<ChiTietHSXLVPVVBGQ> builder)
    {
        builder.ToTable(typeof(ChiTietHSXLVPVVBGQ).Name);
    }
}