using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Infrastructure.Persistence;
using CatalogService.Infrastructure.Repositories;
using Infrastructure.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CatalogService.Infrastructure.HttpClients;

namespace CatalogService.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        var builder = new SqlConnectionStringBuilder(connectionString);

        var serviceProvider = services.BuildServiceProvider();
        var env = serviceProvider.GetService<IWebHostEnvironment>();
        var isDevelopment = env.IsDevelopment();

        services.AddDbContext<CatalogServiceContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                builder => builder.MigrationsAssembly(typeof(CatalogServiceContext).Assembly.FullName))
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                        .EnableDetailedErrors(isDevelopment)
                        .EnableSensitiveDataLogging(isDevelopment);
        });

        services.AddHttpClient<IUserServiceClient, UserServiceHttpClient>(client =>
        {
            #if DEBUG
                client.BaseAddress = new Uri(configuration["UserService:Url"]);
            #else
                client.BaseAddress = new Uri("http://identityservice.api:5104");
            #endif
        });

        services.AddScoped<CatalogServiceContextSeed>();
        services.AddScoped<ITinhThanhPhoRepository, TinhThanhPhoRepository>();
        services.AddScoped<IQuanHuyenRepository, QuanHuyenRepository>();
        services.AddScoped<IXaPhuongRepository, XaPhuongRepository>();
        services.AddScoped<ILinhVucXuPhatRepository, LinhVucXuPhatRepository>();
        services.AddScoped<IChiTietLinhVucXuPhatRepository, ChiTietLinhVucXuPhatRepository>();
        services.AddScoped<ILoaiVanBanRepository, LoaiVanBanRepository>();
        services.AddScoped<ICoQuanBanHanhRepository, CoQuanBanHanhRepository>();
        services.AddScoped<IVanBanLienQuanRepository, VanBanLienQuanRepository>();
        services.AddScoped<IVanBanPhapLuatRepository, VanBanPhapLuatRepository>();
        services.AddScoped<IDieuKhoanXuPhatRepository, DieuKhoanXuPhatRepository>();
        services.AddScoped<IVanBanGiaiQuyetRepository, VanBanGiaiQuyetRepository>();
        services.AddScoped<IDanhMucDinhDanhRepository, DanhMucDinhDanhRepository>();
        services.AddScoped<IThamQuyenXuPhatRepository, ThamQuyenXuPhatRepository>();
        services.AddScoped<IQuyetDinhXuPhatRepository, QuyetDinhXuPhatRepository>();
        services.AddScoped<IHinhThucXuPhatChinhRepository, HinhThucXuPhatChinhRepository>();
        services.AddScoped<IHinhThucXuPhatBoSungRepository, HinhThucXuPhatBoSungRepository>();
        services.AddScoped<ITangVatPhuongTienTamGiuRepository, TangVatPhuongTienTamGiuRepository>();
        services.AddScoped<IGiayPhepTamGiuRepository, GiayPhepTamGiuRepository>();
        services.AddScoped<ICoQuanRepository, CoQuanRepository>();
        services.AddScoped<ICongDanRepository, CongDanRepository>();
        services.AddScoped<IDieuKhoanBoSungKhacPhucRepository, DieuKhoanBoSungKhacPhucRepository>();
        services.AddScoped<IHoSoXuLyViPhamRepository, HoSoXuLyViPhamRepository>();
        services.AddScoped<IHSVPVanBanGiaiQuyetRepository, HSVPVanBanGiaiQuyetRepository>();
        services.AddScoped<IHanhViViPhamRepository, HanhViViPhamRepository>();
        services.AddScoped<IChiTietHSXLVPVVBGQRepository, ChiTietHSXLVPVVBGQRepository>();
        services.AddScoped<IToChucRepository, ToChucRepository>();
        services.AddScoped<IKhoBacRepository, KhoBacRepository>();
        services.AddScoped<IKetQuaXuPhatHanhChinhRepository, KetQuaXuPhatHanhChinhRepository>();
        services.AddScoped<IKetQuaXuPhatTruyCuuHSRepository, KetQuaXuPhatTruyCuuHSRepository>();
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        return services;
    }
}