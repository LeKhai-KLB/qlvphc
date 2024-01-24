﻿// <auto-generated />
using System;
using CatalogService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CatalogService.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(CatalogServiceContext))]
    [Migration("20240124093746_alterVanBanGiaiQuyet")]
    partial class alterVanBanGiaiQuyet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CatalogService.Domain.Entities.ChiTietLinhVucXuPhat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Diem")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("DieuKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int>("LinhVucXuPhatId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhatCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiCapNhatCuoi")
                        .HasColumnType("int");

                    b.Property<int>("NguoiTao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LinhVucXuPhatId");

                    b.ToTable("ChiTietLinhVucXuPhat", (string)null);
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.CoQuanBanHanh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("NgayCapNhatCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiCapNhatCuoi")
                        .HasColumnType("int");

                    b.Property<int>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("NhomCoQuan")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenCoQuan")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("CoQuanBanHanh", (string)null);
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.DieuKhoanXuPhat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Diem")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Dieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Khoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("LinhVucXuPhatId")
                        .HasColumnType("int");

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

                    b.HasKey("Id");

                    b.HasIndex("LinhVucXuPhatId");

                    b.ToTable("DieuKhoanXuPhat", (string)null);
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.LinhVucXuPhat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DanChungNghiDinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("HanhVi_QuyetDinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("HetHieuLuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("HienThi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("NgayCapNhatCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NghiDinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<int?>("NguoiCapNhatCuoi")
                        .HasColumnType("int");

                    b.Property<int>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("NhomLinhVuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenLinhVuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("LinhVucXuPhat", (string)null);
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.LoaiVanBan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("NgayCapNhatCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiCapNhatCuoi")
                        .HasColumnType("int");

                    b.Property<int>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("LoaiVanBan", (string)null);
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.QuanHuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

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

            modelBuilder.Entity("CatalogService.Domain.Entities.TinhThanhPho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

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

            modelBuilder.Entity("CatalogService.Domain.Entities.VanBanGiaiQuyet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MaGiayTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("NgayCapNhatCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiCapNhatCuoi")
                        .HasColumnType("int");

                    b.Property<int>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("TenGiayTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TheoNghiDinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("VanBanGiaiQuyet", (string)null);
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.VanBanLienQuan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("NgayBanHanh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("NgayCapNhatCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiCapNhatCuoi")
                        .HasColumnType("int");

                    b.Property<int>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("VanBanPhapLuatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VanBanPhapLuatId");

                    b.ToTable("VanBanLienQuan", (string)null);
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.VanBanPhapLuat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoQuanBanHanhId")
                        .HasColumnType("int");

                    b.Property<string>("DuongDanUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("LoaiVanBanId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBanHanh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("NgayCapNhatCuoi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayHieuLuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NguoiCapNhatCuoi")
                        .HasColumnType("int");

                    b.Property<int>("NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("SoHieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<string>("TrichYeuNoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Id");

                    b.HasIndex("CoQuanBanHanhId");

                    b.HasIndex("LoaiVanBanId");

                    b.ToTable("VanBanPhapLuat", (string)null);
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.XaPhuong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

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

            modelBuilder.Entity("CatalogService.Domain.Entities.ChiTietLinhVucXuPhat", b =>
                {
                    b.HasOne("CatalogService.Domain.Entities.LinhVucXuPhat", "LinhVucXuPhat")
                        .WithMany("ChiTietLinhVucXuPhat")
                        .HasForeignKey("LinhVucXuPhatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinhVucXuPhat");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.DieuKhoanXuPhat", b =>
                {
                    b.HasOne("CatalogService.Domain.Entities.LinhVucXuPhat", "LinhVucXuPhat")
                        .WithMany()
                        .HasForeignKey("LinhVucXuPhatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinhVucXuPhat");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.QuanHuyen", b =>
                {
                    b.HasOne("CatalogService.Domain.Entities.TinhThanhPho", "TinhThanhPho")
                        .WithMany("QuanHuyen")
                        .HasForeignKey("TinhThanhPhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TinhThanhPho");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.VanBanLienQuan", b =>
                {
                    b.HasOne("CatalogService.Domain.Entities.VanBanPhapLuat", "VanBanPhapLuat")
                        .WithMany("VanBanLienQuan")
                        .HasForeignKey("VanBanPhapLuatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VanBanPhapLuat");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.VanBanPhapLuat", b =>
                {
                    b.HasOne("CatalogService.Domain.Entities.CoQuanBanHanh", "CoQuanBanHanh")
                        .WithMany("VanBanPhapLuat")
                        .HasForeignKey("CoQuanBanHanhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CatalogService.Domain.Entities.LoaiVanBan", "LoaiVanBan")
                        .WithMany("VanBanPhapLuat")
                        .HasForeignKey("LoaiVanBanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoQuanBanHanh");

                    b.Navigation("LoaiVanBan");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.XaPhuong", b =>
                {
                    b.HasOne("CatalogService.Domain.Entities.QuanHuyen", "QuanHuyen")
                        .WithMany("XaPhuong")
                        .HasForeignKey("QuanHuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuanHuyen");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.CoQuanBanHanh", b =>
                {
                    b.Navigation("VanBanPhapLuat");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.LinhVucXuPhat", b =>
                {
                    b.Navigation("ChiTietLinhVucXuPhat");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.LoaiVanBan", b =>
                {
                    b.Navigation("VanBanPhapLuat");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.QuanHuyen", b =>
                {
                    b.Navigation("XaPhuong");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.TinhThanhPho", b =>
                {
                    b.Navigation("QuanHuyen");
                });

            modelBuilder.Entity("CatalogService.Domain.Entities.VanBanPhapLuat", b =>
                {
                    b.Navigation("VanBanLienQuan");
                });
#pragma warning restore 612, 618
        }
    }
}
