﻿using System.ComponentModel.DataAnnotations.Schema;
using Alertify.Domain.Common;

namespace Alertify.Domain.Entities
{
    public class UnsentMessage : BaseAuditableEntity
    {
        public int SmsManagerId { get; set; }
        public string? ErrorMessage { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(SmsManagerId))]
        public virtual SmsManager SmsManager { get; set; }
    }
}
