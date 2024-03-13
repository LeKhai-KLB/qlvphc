using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class CoQuanConfiguration : IEntityTypeConfiguration<CoQuan>
{
    public void Configure(EntityTypeBuilder<CoQuan> builder)
    {
        builder.ToTable(typeof(CoQuan).Name);
    }
}