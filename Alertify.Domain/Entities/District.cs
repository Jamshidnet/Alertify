using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alertify.Domain.Common;

namespace Alertify.Domain.Entities
{
    public class District : BaseAuditableEntity
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public int RegionId { get; set; }
    }
}
