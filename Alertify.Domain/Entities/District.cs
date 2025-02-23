using System.ComponentModel.DataAnnotations.Schema;
using Alertify.Domain.Common;

namespace Alertify.Domain.Entities
{
    public class District : BaseAuditableEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public virtual Region Region { get; set; }
    }
}
