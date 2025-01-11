using Alertify.Application.Common.Interfaces;

namespace Alertify.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
