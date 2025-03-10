﻿using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistence.Configurations;

public class XaPhuongConfiguration : IEntityTypeConfiguration<XaPhuong>
{
    public void Configure(EntityTypeBuilder<XaPhuong> builder)
    {
        builder.ToTable(typeof(XaPhuong).Name);

        builder.Property(e => e.NgayTao)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.IsDeleted)
                .HasColumnType("bit")
                .HasDefaultValueSql("0");
    }
}