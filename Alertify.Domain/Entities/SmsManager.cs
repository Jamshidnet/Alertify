using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alertify.Domain.Common;

namespace Alertify.Domain.Entities
{
    public class SmsManager : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int StatusId { get; set; }
    }
}
