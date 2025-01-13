using Alertify.Application.UseCases.SmsManagers.Commands.CreateSmsManager;
using Alertify.Application.UseCases.SmsManagers.Commands.DeleteSmsManager;
using Alertify.Application.UseCases.SmsManagers.Commands.UpdateSmsManager;
using Alertify.Application.UseCases.SmsManagers.Queries.GetAllSmsManagers;
using Alertify.Application.UseCases.SmsManagers.Queries.GetSmsManagerById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SmsManagerController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateSmsManager()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateSmsManager([FromForm] CreateSmsManagerCommand SmsManager)
        {
            await Mediator.Send(SmsManager);

            return RedirectToAction("GetAllSmsManagers");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateSmsManagerFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllSmsManagers()
        {
            var SmsManagers = await Mediator.Send(new GetAllSmsManagersQuery());

            return View(SmsManagers);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateSmsManager(int Id)
        {
            var SmsManager = await Mediator.Send(new GetSmsManagerByIdQuery(Id));

            return View(SmsManager);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateSmsManager([FromForm] UpdateSmsManagerCommand SmsManager)
        {
            await Mediator.Send(SmsManager);
            return RedirectToAction("GetAllSmsManagers");
        }

        public async ValueTask<IActionResult> DeleteSmsManager(int Id)
        {
            await Mediator.Send(new DeleteSmsManagerCommand(Id));

            return RedirectToAction("GetAllSmsManagers");
        }
    }
}
