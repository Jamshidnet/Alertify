using Alertify.Application.UseCases.Districts.Queries.GetAllDistricts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DistrictController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllDistricts()
        {
            var Districts = await Mediator.Send(new GetAllDistrictsQuery());

            return View(Districts);
        }
    }
}
