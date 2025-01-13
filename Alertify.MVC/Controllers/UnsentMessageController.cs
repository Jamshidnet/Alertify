using Alertify.Application.UseCases.UnsentMessages.Commands.CreateUnsentMessage;
using Alertify.Application.UseCases.UnsentMessages.Commands.DeleteUnsentMessage;
using Alertify.Application.UseCases.UnsentMessages.Commands.UpdateUnsentMessage;
using Alertify.Application.UseCases.UnsentMessages.Queries.GetAllUnsentMessages;
using Alertify.Application.UseCases.UnsentMessages.Queries.GetUnsentMessageById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UnsentMessageController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateUnsentMessage()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateUnsentMessage([FromForm] CreateUnsentMessageCommand UnsentMessage)
        {
            await Mediator.Send(UnsentMessage);

            return RedirectToAction("GetAllUnsentMessages");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateUnsentMessageFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllUnsentMessages()
        {
            var UnsentMessages = await Mediator.Send(new GetAllUnsentMessagesQuery());

            return View(UnsentMessages);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateUnsentMessage(int Id)
        {
            var UnsentMessage = await Mediator.Send(new GetUnsentMessageByIdQuery(Id));

            return View(UnsentMessage);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateUnsentMessage([FromForm] UpdateUnsentMessageCommand UnsentMessage)
        {
            await Mediator.Send(UnsentMessage);
            return RedirectToAction("GetAllUnsentMessages");
        }

        public async ValueTask<IActionResult> DeleteUnsentMessage(int Id)
        {
            await Mediator.Send(new DeleteUnsentMessageCommand(Id));

            return RedirectToAction("GetAllUnsentMessages");
        }
    }
}
