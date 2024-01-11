﻿// <auto-generated />
using System;
using DanhMucService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DanhMucService.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DanhMucServiceContext))]
    [Migration("20240111004314_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DanhMucService.Domain.Entities.QuanHuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("false");

                    b.Property<string>("MaDinhDanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhatCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("NguoiCapNhatCuoi")
                        .HasColumnType("int");

                    b.Property<int>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TinhThanhPhoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TinhThanhPhoId");

                    b.ToTable("QuanHuyen", (string)null);
                });

            modelBuilder.Entity("DanhMucService.Domain.Entities.TinhThanhPho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("false");

                    b.Property<string>("MaDinhDanh")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("NgayCapNhatCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("NguoiCapNhatCuoi")
                        .HasColumnType("int");

                    b.Property<int>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("TinhThanhPho", (string)null);
                });

            modelBuilder.Entity("DanhMucService.Domain.Entities.XaPhuong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("false");

                    b.Property<string>("MaDinhDanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhatCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("NguoiCapNhatCuoi")
                        .HasColumnType("int");

                    b.Property<int>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<int>("QuanHuyenId")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuanHuyenId");

                    b.ToTable("XaPhuong", (string)null);
                });

            modelBuilder.Entity("DanhMucService.Domain.Entities.QuanHuyen", b =>
                {
                    b.HasOne("DanhMucService.Domain.Entities.TinhThanhPho", "TinhThanhPho")
                        .WithMany("QuanHuyen")
                        .HasForeignKey("TinhThanhPhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TinhThanhPho");
                });

            modelBuilder.Entity("DanhMucService.Domain.Entities.XaPhuong", b =>
                {
                    b.HasOne("DanhMucService.Domain.Entities.QuanHuyen", "QuanHuyen")
                        .WithMany("XaPhuong")
                        .HasForeignKey("QuanHuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuanHuyen");
                });

            modelBuilder.Entity("DanhMucService.Domain.Entities.QuanHuyen", b =>
                {
                    b.Navigation("XaPhuong");
                });

            modelBuilder.Entity("DanhMucService.Domain.Entities.TinhThanhPho", b =>
                {
                    b.Navigation("QuanHuyen");
                });
#pragma warning restore 612, 618
        }
    }
}
