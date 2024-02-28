using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class ThamQuyenXuPhatConfiguration : IEntityTypeConfiguration<ThamQuyenXuPhat>
{
    public void Configure(EntityTypeBuilder<ThamQuyenXuPhat> builder)
    {
        builder.ToTable(typeof(ThamQuyenXuPhat).Name);

        builder.Property(e => e.IsDeleted)
                .HasColumnType("bit")
                .HasDefaultValueSql("0");
    }
}