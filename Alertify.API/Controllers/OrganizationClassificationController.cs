using Alertify.Application.UseCases.OrganizationClassifications;
using Alertify.Application.UseCases.OrganizationClassifications.Queries.GetAllOrganizationClassifications;
using Alertify.Application.UseCases.OrganizationClassifications.Queries.GetOrganizationClassificationById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.API.Controllers
{
    /// <summary>
    /// [Authorize(Roles = "Admin")]
    /// </summary>
    public class OrganizationClassificationController : ApiBaseController
    {

        [HttpGet("[action]")]
        public async ValueTask<OrganizationClassificationResponse> GetOrganizationClassificationById(int Id)
        {
            return await Mediator.Send(new GetOrganizationClassificationByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<OrganizationClassificationResponse>> GetAllOrganizationClassifications()
        {
            return await Mediator.Send(new GetAllOrganizationClassificationsQuery());
        }
    }
}
