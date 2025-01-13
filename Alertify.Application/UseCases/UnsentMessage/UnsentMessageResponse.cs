namespace Alertify.Application.UseCases.UnsentMessages
{
    public class UnsentMessageResponse
    {
        public int Id { get; set; }
        public int SmsManagerId { get; set; }
        public string? ErrorMessage { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
