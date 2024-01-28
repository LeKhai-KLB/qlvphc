﻿using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class DanhMucDinhDanhConfiguration : IEntityTypeConfiguration<DanhMucDinhDanh>
{
    public void Configure(EntityTypeBuilder<DanhMucDinhDanh> builder)
    {
        builder.ToTable(typeof(DanhMucDinhDanh).Name);

        builder.Property(e => e.NgayTao)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.IsDeleted)
                .HasColumnType("bit")
                .HasDefaultValueSql("0");
    }
}