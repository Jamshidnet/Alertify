using System;
using System.Collections.Generic;
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

        public Region Region { get; set; }
        public District District { get; set; }
        public OrganizationClassification OrganizationClassification { get; set; }
    }
}
