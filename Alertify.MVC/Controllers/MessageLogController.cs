using Alertify.Application.UseCases.MessageLogs.Commands.CreateMessageLog;
using Alertify.Application.UseCases.MessageLogs.Commands.DeleteMessageLog;
using Alertify.Application.UseCases.MessageLogs.Queries.GetAllMessageLogs;
using Alertify.Application.UseCases.MessageLogs.Queries.GetMessageLogById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MessageLogController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateMessageLog()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateMessageLog([FromForm] CreateMessageLogCommand MessageLog)
        {
            await Mediator.Send(MessageLog);

            return RedirectToAction("GetAllMessageLogs");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateMessageLogFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllMessageLogs()
        {
            var MessageLogs = await Mediator.Send(new GetAllMessageLogsQuery());

            return View(MessageLogs);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateMessageLog(int Id)
        {
            var MessageLog = await Mediator.Send(new GetMessageLogByIdQuery(Id));

            return View(MessageLog);
        }

        public async ValueTask<IActionResult> DeleteMessageLog(int Id)
        {
            await Mediator.Send(new DeleteMessageLogCommand(Id));

            return RedirectToAction("GetAllMessageLogs");
        }
    }
}
