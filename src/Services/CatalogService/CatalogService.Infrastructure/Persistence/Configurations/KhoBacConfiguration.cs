using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class KhoBacConfiguration : IEntityTypeConfiguration<KhoBac>
{
    public void Configure(EntityTypeBuilder<KhoBac> builder)
    {
        builder.ToTable(typeof(KhoBac).Name);
    }
}