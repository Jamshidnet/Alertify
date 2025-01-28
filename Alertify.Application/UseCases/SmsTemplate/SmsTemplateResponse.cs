namespace Alertify.Application.UseCases.SmsTemplates
{
    public class SmsTemplateResponse
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public int OrganizationId { get; set; }
        public string Message { get; set; }
        public long TemplateId { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
