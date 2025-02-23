using Alertify.Domain.Common;

namespace Alertify.Domain.Entities
{
    public class Status : BaseAuditableEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
    }
}
