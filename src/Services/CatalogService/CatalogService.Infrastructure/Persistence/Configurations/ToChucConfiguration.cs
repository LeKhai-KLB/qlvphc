using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class ToChucConfiguration : IEntityTypeConfiguration<ToChuc>
{
    public void Configure(EntityTypeBuilder<ToChuc> builder)
    {
        builder.ToTable(typeof(ToChuc).Name);
    }
}