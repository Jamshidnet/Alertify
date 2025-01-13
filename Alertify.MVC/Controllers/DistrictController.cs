using Alertify.Application.UseCases.Districts.Queries.GetAllDistricts;
using Alertify.Application.UseCases.Districts.Queries.GetDistrictById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DistrictController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateDistrict()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateDistrictFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllDistricts()
        {
            var Districts = await Mediator.Send(new GetAllDistrictsQuery());

            return View(Districts);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateDistrict(int Id)
        {
            var District = await Mediator.Send(new GetDistrictByIdQuery(Id));

            return View(District);
        }
    }
}
