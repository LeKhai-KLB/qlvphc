using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class CoQuanBanHanhConfiguration : IEntityTypeConfiguration<CoQuanBanHanh>
{
    public void Configure(EntityTypeBuilder<CoQuanBanHanh> builder)
    {
        builder.ToTable(typeof(CoQuanBanHanh).Name);
    }
}