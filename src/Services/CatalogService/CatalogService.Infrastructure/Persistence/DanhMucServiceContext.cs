using Contracts.Common.Events;
using Contracts.Common.Interfaces;
using Contracts.Domains.Interfaces;
using CatalogService.Domain.Entities;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

namespace CatalogService.Infrastructure.Persistence;

public class CatalogServiceContext : DbContext
{
    private readonly IMediator _mediator;
    private readonly ILogger _logger;
    private List<BaseEvent> _domainEvents;

    private void SetBaseEventsBeforeSaveChanges()
    {
        var domainEntities = ChangeTracker.Entries<IEventEntity>()
            .Select(x => x.Entity)
            .Where(x => x.DomainEvents().Any())
            .ToList();

        _domainEvents = domainEntities
            .SelectMany(x => x.DomainEvents())
            .ToList();

        domainEntities.ForEach(x => x.ClearDomainEvent());
    }

    public CatalogServiceContext()
    {
    }

    public CatalogServiceContext(DbContextOptions<CatalogServiceContext> options, ILogger logger, IMediator mediator) : base(options)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public DbSet<TinhThanhPho> TinhThanhPhos { get; set; }
    public DbSet<QuanHuyen> QuanHuyens { get; set; }
    public DbSet<XaPhuong> XaPhuongs { get; set; }
    public DbSet<LinhVucXuPhat> LinhVucXuPhats { get; set; }
    public DbSet<ChiTietLinhVucXuPhat> ChiTietLinhVucXuPhats { get; set; }
    public DbSet<CoQuanBanHanh> CoQuanBanHanhs { get; set; }
    public DbSet<LoaiVanBan> LoaiVanBans { get; set; }
    public DbSet<VanBanPhapLuat> VanBanPhapLuats { get; set; }
    public DbSet<VanBanLienQuan> VanBanLienQuans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("name = DefaultConnectionString");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetBaseEventsBeforeSaveChanges();
        var modified = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified ||
                e.State == EntityState.Added ||
                e.State == EntityState.Deleted);

        foreach (var item in modified)
        {
            switch (item.State)
            {
                case EntityState.Added:
                    if (item.Entity is IDateTracking addedEntity)
                    {
                        addedEntity.NgayTao = DateTime.UtcNow;
                        item.State = EntityState.Added;
                    }
                    break;

                case EntityState.Modified:
                    Entry(item.Entity).Property("Id").IsModified = false;

                    if (item.Entity is IDateTracking modifiedEntity)
                    {
                        modifiedEntity.NgayCapNhatCuoi = DateTime.UtcNow;
                        item.State = EntityState.Modified;
                    }
                    break;
            }
        }
        var result = await base.SaveChangesAsync(cancellationToken);

        await _mediator.DispatchDomainEventAsync(_domainEvents, _logger);

        return result;
    }
}