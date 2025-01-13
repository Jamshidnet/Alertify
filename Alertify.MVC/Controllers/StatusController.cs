using Alertify.Application.UseCases.Statuss.Queries.GetAllStatuss;
using Alertify.Application.UseCases.Statuss.Queries.GetStatusById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatusController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateStatus()
        {
            return View();
        }


        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateStatusFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllStatuss()
        {
            var Statuss = await Mediator.Send(new GetAllStatussQuery());

            return View(Statuss);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateStatus(int Id)
        {
            var Status = await Mediator.Send(new GetStatusByIdQuery(Id));

            return View(Status);
        }
    }
}
