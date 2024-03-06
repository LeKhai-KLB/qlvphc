using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class QuyetDinhXuPhatConfiguration : IEntityTypeConfiguration<QuyetDinhXuPhat>
{
    public void Configure(EntityTypeBuilder<QuyetDinhXuPhat> builder)
    {
        builder.ToTable(typeof(QuyetDinhXuPhat).Name);
    }
}