namespace Alertify.Application.UseCases.Districts
{
    public class DistrictResponse
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
