using IdentityService.Application.Common.Interfaces;
using IdentityService.Domain.Entities;
using IdentityService.Infrastructure.Persistence;
using IdentityService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityService.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var builder = new SqlConnectionStringBuilder(connectionString);

        var serviceProvider = services.BuildServiceProvider();
        var env = serviceProvider.GetService<IWebHostEnvironment>();
        var isDevelopment = env.IsDevelopment();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                      .EnableDetailedErrors(isDevelopment)
                      .EnableSensitiveDataLogging(isDevelopment);
        });

        services.AddScoped(typeof(IEntityRepository<,>), typeof(EntityRepository<,>));

        return services;
    }
}