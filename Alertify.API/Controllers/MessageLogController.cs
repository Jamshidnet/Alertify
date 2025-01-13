using Alertify.Application.UseCases.MessageLogs;
using Alertify.Application.UseCases.MessageLogs.Commands.CreateMessageLog;
using Alertify.Application.UseCases.MessageLogs.Commands.DeleteMessageLog;
using Alertify.Application.UseCases.MessageLogs.Queries.GetAllMessageLogs;
using Alertify.Application.UseCases.MessageLogs.Queries.GetMessageLogById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.API.Controllers
{
    public class MessageLogController : ApiBaseController
    {
        [HttpPost("[action]")]
        public async ValueTask<int> CreateMessageLog(CreateMessageLogCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<MessageLogResponse> GetMessageLogById(int Id)
        {
            return await Mediator.Send(new GetMessageLogByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<MessageLogResponse>> GetAllMessageLogs()
        {
            return await Mediator.Send(new GetAllMessageLogsQuery());
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteMessageLog(DeleteMessageLogCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
