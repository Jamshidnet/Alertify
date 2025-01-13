using Alertify.Application.UseCases.Regions.Queries.GetAllRegions;
using Alertify.Application.UseCases.Regions.Queries.GetRegionById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegionController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateRegion()
        {
            return View();
        }


        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateRegionFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllRegions()
        {
            var Regions = await Mediator.Send(new GetAllRegionsQuery());

            return View(Regions);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateRegion(int Id)
        {
            var Region = await Mediator.Send(new GetRegionByIdQuery(Id));

            return View(Region);
        }
    }
}
