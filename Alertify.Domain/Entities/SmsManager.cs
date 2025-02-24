﻿using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey(nameof(TemplateId))]
        public virtual SmsTemplate SmsTemplate { get; set; }
    }
}
