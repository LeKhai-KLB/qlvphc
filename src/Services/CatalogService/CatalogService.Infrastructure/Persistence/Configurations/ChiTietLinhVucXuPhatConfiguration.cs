using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class ChiTietLinhVucXuPhatConfiguration : IEntityTypeConfiguration<ChiTietLinhVucXuPhat>
{
    public void Configure(EntityTypeBuilder<ChiTietLinhVucXuPhat> builder)
    {
        builder.ToTable(typeof(ChiTietLinhVucXuPhat).Name);
    }
}