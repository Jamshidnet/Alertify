using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alertify.Domain.Common;

namespace Alertify.Domain.Entities
{
    public class MessageLog : BaseAuditableEntity
    {
        public int UserId  { get; set; }
        public int TemplateId  { get; set; }
        public int OrganizationId  { get; set; }
        public string RecieverPhoneNumber { get; set; }
        public string? RecieverFullName  { get; set; }
    }
}
