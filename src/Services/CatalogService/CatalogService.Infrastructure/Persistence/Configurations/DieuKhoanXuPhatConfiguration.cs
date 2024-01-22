using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class DieuKhoanXuPhatConfiguration : IEntityTypeConfiguration<DieuKhoanXuPhat>
{
    public void Configure(EntityTypeBuilder<DieuKhoanXuPhat> builder)
    {
        builder.ToTable(typeof(DieuKhoanXuPhat).Name);

        builder.Property(e => e.NgayTao)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.IsDeleted)
                .HasColumnType("bit")
                .HasDefaultValueSql("0");
    }
}