using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class GiayPhepTamGiuConfiguration : IEntityTypeConfiguration<GiayPhepTamGiu>
{
    public void Configure(EntityTypeBuilder<GiayPhepTamGiu> builder)
    {
        builder.ToTable(typeof(GiayPhepTamGiu).Name);
    }
}