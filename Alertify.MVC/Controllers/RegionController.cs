using Alertify.Application.UseCases.Regions.Queries.GetAllRegions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegionController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllRegions()
        {
            var Regions = await Mediator.Send(new GetAllRegionsQuery());

            return View(Regions);
        }
    }
}
