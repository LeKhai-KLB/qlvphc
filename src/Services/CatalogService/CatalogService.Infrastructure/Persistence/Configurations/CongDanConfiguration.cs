using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class CongDanConfiguration : IEntityTypeConfiguration<CongDan>
{
    public void Configure(EntityTypeBuilder<CongDan> builder)
    {
        builder.ToTable(typeof(CongDan).Name);
    }
}