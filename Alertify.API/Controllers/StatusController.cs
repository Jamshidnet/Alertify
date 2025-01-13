using Alertify.Application.UseCases.Statuss;
using Alertify.Application.UseCases.Statuss.Queries.GetAllStatuss;
using Alertify.Application.UseCases.Statuss.Queries.GetStatusById;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.API.Controllers
{
    /// <summary>
    /// [Authorize(Roles = "Admin")]
    /// </summary>
    public class StatusController : ApiBaseController
    {

        [HttpGet("[action]")]
        public async ValueTask<StatusResponse> GetStatusById(int Id)
        {
            return await Mediator.Send(new GetStatusByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<StatusResponse>> GetAllStatuss()
        {
            return await Mediator.Send(new GetAllStatussQuery());
        }
    }
}
