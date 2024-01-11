using DanhMucService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanhMucService.Infrastructure.Persistence.Configurations
{
    public class QuanHuyenConfiguration : IEntityTypeConfiguration<QuanHuyen>
    {
        public void Configure(EntityTypeBuilder<QuanHuyen> builder)
        {
            builder.ToTable(typeof(QuanHuyen).Name);

            builder.Property(e => e.NgayTao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.IsDeleted)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");
        }
    }
}