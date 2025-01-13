using Alertify.Application.UseCases.SmsManagers;
using Alertify.Application.UseCases.SmsManagers.Commands.CreateSmsManager;
using Alertify.Application.UseCases.SmsManagers.Commands.DeleteSmsManager;
using Alertify.Application.UseCases.SmsManagers.Commands.UpdateSmsManager;
using Alertify.Application.UseCases.SmsManagers.Queries.GetAllSmsManagers;
using Alertify.Application.UseCases.SmsManagers.Queries.GetSmsManagerById;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.API.Controllers
{
    /// <summary>
    /// [Authorize(Roles = "Admin")]
    /// </summary>
    public class SmsManagerController : ApiBaseController
    {

        [HttpPost("[action]")]
        public async ValueTask<int> CreateSmsManager(CreateSmsManagerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<SmsManagerResponse> GetSmsManagerById(int Id)
        {
            return await Mediator.Send(new GetSmsManagerByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<SmsManagerResponse>> GetAllSmsManagers()
        {
            return await Mediator.Send(new GetAllSmsManagersQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateSmsManager(UpdateSmsManagerCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteSmsManager(DeleteSmsManagerCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
