namespace Alertify.Application.UseCases.Organizations
{
    public class OrganizationResponse
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string? Inn { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int RegionId { get; set; }
        public int DistrictId { get; set; }
        public int OrganizationClassificationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
