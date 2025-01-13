namespace Alertify.Application.UseCases.SmsManagers
{
    public class SmsManagerResponse
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int StatusId { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
