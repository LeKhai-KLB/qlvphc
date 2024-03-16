using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Common.Constants;

namespace CatalogService.Infrastructure.Persistence;

public class CatalogServiceContextSeed
{
    private readonly ILogger _logger;
    private readonly CatalogServiceContext _context;

    public CatalogServiceContextSeed(ILogger logger, CatalogServiceContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                // Drop the existing database
                //await _context.Database.EnsureDeletedAsync();

                // Apply migrations to create a new database
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task TrySeedCongDanAsync()
    {
        if (!_context.CongDans.Any())
        {
            var congdans = new List<CongDan>();

            for(var i = 0; i < 30; i++)
            {
                congdans.Add(new CongDan
                {
                    HoTen = $"Cong dan {i}",
                    NgaySinh = new DateTime(1988, 1, i + 1),
                    GioiTinh = Genders.Male,
                    LoaiGiayToDinhDanh = LoaiGiayToDinhDanh.CCCD,
                    SoLoaiGiayTo = "123456789000",
                    DiaChi = $"Số nhà {i + 1}, ABCyxz"
                });
            }

            // Add danhMucs to the context
            _context.CongDans.AddRange(congdans);

            // Save changes to the database
            await _context.SaveChangesAsync();
        }
    }
}