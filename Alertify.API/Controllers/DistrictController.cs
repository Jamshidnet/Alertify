using Alertify.Application.UseCases.Districts;
using Alertify.Application.UseCases.Districts.Queries.GetAllDistricts;
using Alertify.Application.UseCases.Districts.Queries.GetDistrictById;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.API.Controllers
{
    public class DistrictController : ApiBaseController
    {

        [HttpGet("[action]")]
        public async ValueTask<DistrictResponse> GetDistrictById(int Id)
        {
            return await Mediator.Send(new GetDistrictByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<DistrictResponse>> GetAllDistricts()
        {
            return await Mediator.Send(new GetAllDistrictsQuery());
        }
    }
}
