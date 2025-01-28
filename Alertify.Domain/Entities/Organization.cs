using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alertify.Domain.Common;

namespace Alertify.Domain.Entities
{
    public class Organization : BaseAuditableEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string? Inn { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int RegionId { get; set; }
        public int DistrictId { get; set; }
        public int OrganizationClassificationId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? SecretKey { get; set; }

        [ForeignKey(nameof(RegionId))]
        public virtual Region Region { get; set; }
        [ForeignKey(nameof(DistrictId))]
        public virtual District District { get; set; }
        [ForeignKey(nameof(OrganizationClassificationId))]
        public virtual OrganizationClassification OrganizationClassification { get; set; }
    }
}
