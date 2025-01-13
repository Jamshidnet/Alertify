using Alertify.Application.UseCases.UnsentMessages;
using Alertify.Application.UseCases.UnsentMessages.Commands.CreateUnsentMessage;
using Alertify.Application.UseCases.UnsentMessages.Commands.DeleteUnsentMessage;
using Alertify.Application.UseCases.UnsentMessages.Commands.UpdateUnsentMessage;
using Alertify.Application.UseCases.UnsentMessages.Queries.GetAllUnsentMessages;
using Alertify.Application.UseCases.UnsentMessages.Queries.GetUnsentMessageById;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.API.Controllers
{
    /// <summary>
    /// [Authorize(Roles = "Admin")]
    /// </summary>
    public class UnsentMessageController : ApiBaseController
    {

        [HttpPost("[action]")]
        public async ValueTask<int> CreateUnsentMessage(CreateUnsentMessageCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<UnsentMessageResponse> GetUnsentMessageById(int Id)
        {
            return await Mediator.Send(new GetUnsentMessageByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<UnsentMessageResponse>> GetAllUnsentMessages()
        {
            return await Mediator.Send(new GetAllUnsentMessagesQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateUnsentMessage(UpdateUnsentMessageCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteUnsentMessage(DeleteUnsentMessageCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
