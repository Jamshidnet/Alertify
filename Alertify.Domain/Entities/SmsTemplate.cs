using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alertify.Domain.Common;

namespace Alertify.Domain.Entities
{
    public class SmsTemplate : BaseAuditableEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public int OrganizationId { get; set; }
        public long TemplateId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }
    }
}
