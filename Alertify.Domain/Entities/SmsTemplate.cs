using System.ComponentModel.DataAnnotations.Schema;
using Alertify.Domain.Common;

namespace Alertify.Domain.Entities
{
    public class SmsTemplate : BaseAuditableEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public int OrganizationId { get; set; }
        public long TemplateId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; }
    }
}
