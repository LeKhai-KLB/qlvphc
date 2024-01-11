using DanhMucService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanhMucService.Infrastructure.Persistence.Configurations
{
    public class TinhThanhPhoConfiguration : IEntityTypeConfiguration<TinhThanhPho>
    {
        public void Configure(EntityTypeBuilder<TinhThanhPho> builder)
        {
            builder.ToTable(typeof(TinhThanhPho).Name);

            builder.Property(e => e.NgayTao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.IsDeleted)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("false");
        }
    }
}