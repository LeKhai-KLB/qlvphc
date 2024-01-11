using Contracts.Common.Interfaces;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Infrastructure.Persistence;
using DanhMucService.Infrastructure.Repositories;
using Infrastructure.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DanhMucService.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        var builder = new SqlConnectionStringBuilder(connectionString);

        var serviceProvider = services.BuildServiceProvider();
        var env = serviceProvider.GetService<IWebHostEnvironment>();
        var isDevelopment = env.IsDevelopment();

        services.AddDbContext<DanhMucServiceContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                    builder => builder.MigrationsAssembly(typeof(DanhMucServiceContext).Assembly.FullName))
                    .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                          .EnableDetailedErrors(isDevelopment)
                          .EnableSensitiveDataLogging(isDevelopment);
            });

        services.AddScoped<DanhMucServiceContextSeed>();
        services.AddScoped<ITinhThanhPhoRepository, TinhThanhPhoRepository>();
        services.AddScoped<IQuanHuyenRepository, QuanHuyenRepository>();
        services.AddScoped<IXaPhuongRepository, XaPhuongRepository>();
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        return services;
    }
}