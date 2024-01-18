using Microsoft.EntityFrameworkCore;
using Serilog;

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
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task TrySeedDanhMucAsync()
    {
        /// TODO
    }
}