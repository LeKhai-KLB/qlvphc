using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class HinhThucXuPhatBoSungConfiguration : IEntityTypeConfiguration<HinhThucXuPhatBoSung>
{
    public void Configure(EntityTypeBuilder<HinhThucXuPhatBoSung> builder)
    {
        builder.ToTable(typeof(HinhThucXuPhatBoSung).Name);
    }
}