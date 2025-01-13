﻿namespace Alertify.Application.UseCases.MessageLogs
{
    public class MessageLogResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TemplateId { get; set; }
        public int OrganizationId { get; set; }
        public string RecieverPhoneNumber { get; set; }
        public string? RecieverFullName { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
