using Alertify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<OrganizationClassification> OrganizationClassifications { get; set; }
        public DbSet<SmsManager> SmsManagers { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<SmsTemplate> SmsTemplates { get; set; }
        public DbSet<MessageLog> MessageLogs { get; set; }
        public DbSet<UnsentMessage> UnsentMessages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
