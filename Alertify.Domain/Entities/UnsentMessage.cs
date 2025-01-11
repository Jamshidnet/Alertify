using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alertify.Domain.Common;

namespace Alertify.Domain.Entities
{
    public class UnsentMessage : BaseAuditableEntity
    {
        public int SmsManagerId  { get; set; }
        public string? ErrorMessage  { get; set; }
        public string PhoneNumber  { get; set; }
        public bool IsDeleted  { get; set; }
    }
}
