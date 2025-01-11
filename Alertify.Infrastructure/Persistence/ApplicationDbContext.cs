using System.Reflection;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using Alertify.Domain.Entities.Identity;
using Alertify.Infrastructure.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    public ApplicationDbContext(
         DbContextOptions<ApplicationDbContext> options,
         AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
         : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<OrganizationClassification> OrganizationClassifications { get; set; }
    public DbSet<SmsManager> SmsManagers { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<SmsTemplate> SmsTemplates { get; set; }
    public DbSet<MessageLog> MessageLogs { get; set; }
    public DbSet<UnsentMessage> UnsentMessages { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
