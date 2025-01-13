using Alertify.Application.UseCases.Regions;
using Alertify.Application.UseCases.Regions.Queries.GetAllRegions;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.API.Controllers
{
    /// <summary>
    /// [Authorize(Roles = "Admin")]
    /// </summary>
    public class RegionController : ApiBaseController
    {

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<RegionResponse>> GetAllRegions()
        {
            return await Mediator.Send(new GetAllRegionsQuery());
        }
    }
}
