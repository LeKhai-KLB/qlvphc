using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class LinhVucXuPhatConfiguration : IEntityTypeConfiguration<LinhVucXuPhat>
{
    public void Configure(EntityTypeBuilder<LinhVucXuPhat> builder)
    {
        builder.ToTable(typeof(LinhVucXuPhat).Name);

        builder.Property(e => e.HienThi)
                .HasColumnType("bit")
                .HasDefaultValueSql("0");

        builder.Property(e => e.HetHieuLuc)
                .HasColumnType("bit")
                .HasDefaultValueSql("0");
    }
}