using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class HinhThucXuPhatChinhConfiguration : IEntityTypeConfiguration<HinhThucXuPhatChinh>
{
    public void Configure(EntityTypeBuilder<HinhThucXuPhatChinh> builder)
    {
        builder.ToTable(typeof(HinhThucXuPhatChinh).Name);
    }
}