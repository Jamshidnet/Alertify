namespace Alertify.Application.UseCases.SmsManagers
{
    public class SmsManagerResponse
    {
        public int TemplateId { get; set; }
        public string Template { get; set; }
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}
