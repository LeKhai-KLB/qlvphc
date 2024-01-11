using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DanhMucService.Infrastructure.Persistence
{
    public class DanhMucServiceContextSeed
    {
        private readonly ILogger _logger;
        private readonly DanhMucServiceContext _context;

        public DanhMucServiceContextSeed(ILogger logger, DanhMucServiceContext context)
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
}